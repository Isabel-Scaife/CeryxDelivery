using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RayCasting : MonoBehaviour
{
    [SerializeField]
    private List<LayerMask> interactableLayers;

    [SerializeField]
    private float distance;

    [SerializeField]
    private float minDist;

    public void OnFire(InputAction.CallbackContext context)
    {

        string currentScene = SceneManager.GetActiveScene().name;

        // track mouse phases if holding is necessary
        if (context.phase == InputActionPhase.Started)
        {
            
            // run package raycasting checks
            if(currentScene == "Package")
            {
                PackageSceneClick();
            }
        }
        else if (context.phase == InputActionPhase.Canceled)
        {

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

        // holding any tool
        if (tool != null)
        {

            // drop tool 
            hit = Physics2D.Raycast(worldPos, Vector2.zero, 10.0f, -1, 1f);

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

            // pick up tool 
            hit = Physics2D.Raycast(worldPos, Vector2.zero, 10.0f, interactableLayers[0], 1f);

            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Tool>().SelectTool();
                return;
            }

            // pull letter out 
            hit = Physics2D.Raycast(worldPos, Vector2.zero, 10.0f, interactableLayers[2], 1f);

            if (hit.collider != null)
            {
                if(hit.collider.gameObject.layer == 7)
                {
                    hit.collider.gameObject.GetComponent<Letter>().Raycast();
                    return;
                }
                Debug.Log(hit.collider.gameObject.name);
            }

            PackageManager.Instance.MailObj.GetComponent<Mail>().Raycast();

            // evelope hit 
            //hit = Physics2D.Raycast(worldPos, Vector2.zero, distance, interactableLayers[1], minDist);

            //if (hit.collider != null)
            //{
            //    Debug.Log(hit.collider.gameObject.name);
            //    PackageManager.Instance.MailObj.GetComponent<Mail>().Raycast();
            //    return;
            //}
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
            PackageManager.Instance.Letter.Dragging = false;
        }
    }

}
