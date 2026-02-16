using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RayCasting : MonoBehaviour
{
    [SerializeField]
    private List<LayerMask> interactableLayers;

    private bool mouseDown = false;

    public void OnFire(InputAction.CallbackContext context)
    {

        string currentScene = SceneManager.GetActiveScene().name;

        // track mouse phases if holding is necessary
        if (context.phase == InputActionPhase.Started)
        {
            mouseDown = true;
            
            // run package raycasting checks
            if(currentScene == "Package")
            {
                PackageSceneClick();
            }
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            mouseDown = false;

            // run package raycasting checks
            if (currentScene == "Package")
            {
                PackageSceneStopClick();
            }
        }
    }

   
    private void PackageSceneClick()
    {
        // current tool 
        Tool tool = PackageManager.Instance.CurrentTool;

        // mouse his colliders
        Vector3 worldPos = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit;

        hit = Physics2D.Raycast(worldPos, Vector2.zero, 10.0f, -1, 1f);

        // holding any tool
        if (tool != null)
        {
            // drop tool 
            if (hit.collider == null)
            {
                tool.DropTool();
                return;
            }
            // use tool 
            else
            {
                tool.RayCast();
            }
        }
        // holding nothing
        else
        {

            hit = Physics2D.Raycast(worldPos, Vector2.zero, 10.0f, interactableLayers[0], 1f);

            // pick up tool 
            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Tool>().SelectTool();
                return;
            }

            PackageManager.Instance.MailObj.GetComponent<Mail>().Raycast();
        }
    }

    private void PackageSceneStopClick()
    {
        Tool tool = PackageManager.Instance.CurrentTool;

        // holding tool, reset tool  
        if (tool != null)
        {
            tool.ResetUse();
        }

        // holding nothing, reset drag for mail  
        if (tool == null)
        {
            PackageManager.Instance.MailObj.GetComponent<Mail>().Dragging = false;
        }
    }

}
