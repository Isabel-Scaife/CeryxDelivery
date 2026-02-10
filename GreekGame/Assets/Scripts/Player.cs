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
            // advances dialogue if any is open
            if (DialogueManager.Instance.DialogueIsHappening)
            {
                DialogueManager.Instance.Advance();
            }

            // interacts with current interactable
            else if(interactObject != null)
            {
                interactObject.Interact(this);

                // reset current interact info
                interactObject = null;
                Debug.Log("Interaction Occurred");
            }
        }
    }
}
