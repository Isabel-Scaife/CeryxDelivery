using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Player : PlayerControlled
{
    public override void Interact (InputAction.CallbackContext context)
    {
        // interact with item if something is within range
        if(context.started)
        {
            // interacts with current interactable
            if(interactObject != null)
            {
                interactObject.Interact(this);

                // reset current interact info
                interactObject = null;
                Debug.Log("Interaction Occurred");
            }
        }
    }
}
