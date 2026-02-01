using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCasting : MonoBehaviour
{
    [SerializeField]
    private List<LayerMask> interactableLayers;
    
    private Camera camera;

    private bool mouseDown = false;


    public void OnFire(InputAction.CallbackContext context)
    {
        // track mouse phases if holding is necessary
        if (context.phase == InputActionPhase.Started)
        {
            mouseDown = true;

            // get hit information at mouse cursor 
            Vector3 worldPos = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit;


            // determine if tool was hit, in package scene
            hit = Physics2D.Raycast(worldPos, Vector2.zero, 10.0f, interactableLayers[0]);

            if(hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Tool>().SelectTool();
            }
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            mouseDown = false;
        }
    }

}
