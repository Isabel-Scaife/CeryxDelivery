using System.Collections.Generic;
using UnityEditor.SearchService;
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
        // track mouse phases if holding is necessary
        if (context.phase == InputActionPhase.Started)
        {
            mouseDown = true;

            string currentScene = SceneManager.GetActiveScene().name;
            
            // run package raycasting checks
            if(currentScene == "Package")
            {
                PackageScenceClicks();
            }
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            mouseDown = false;
        }
    }

   
    private void PackageScenceClicks()
    {
        // mouse his colliders
        Vector3 worldPos = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit;

        // nothing hit 
        hit = Physics2D.Raycast(worldPos, Vector2.zero, 10.0f, -1, 1f);

        // check if nothing was hit 
        if (hit.collider == null)
        {
            // drop tool if holding something
            GameObject tool = PackageManager.Instance.CurrentTool;

            if (tool != null)
            {
                PackageManager.Instance.CurrentTool.GetComponent<Tool>().DropTool();
            }

            return;
        }

        // tool hit 
        hit = Physics2D.Raycast(worldPos, Vector2.zero, 10.0f, interactableLayers[0], 1f);

        if (hit.collider != null)
        {
            // select tool 
            hit.collider.gameObject.GetComponent<Tool>().SelectTool();
        }

        // letter hit
        hit = Physics2D.Raycast(worldPos, Vector2.zero, 10.0f, interactableLayers[1], 1f);

        if (hit.collider != null)
        {
            // use current tool, if clicked in right area 
        }
    }

}
