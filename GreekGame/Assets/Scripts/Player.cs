using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Player : PlayerControlled
{
    // components on player
    private Rigidbody2D rb;

    // interactions 
    private Interactable interactObject;

    // movement
    [SerializeField]
    private float speed;
    private Vector2 direction;
    private Vector2 velocity;
    private Vector2 position;

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
