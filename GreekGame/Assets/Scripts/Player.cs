using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Player : MonoBehaviour
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

    private void Awake()
    {
        // gets components
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // update player's position
        velocity = direction * speed;
        position = (Vector2)transform.position + velocity * Time.fixedDeltaTime;
        rb.MovePosition(position);

    }

    public void Interact (InputAction.CallbackContext context)
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

    public void Move (InputAction.CallbackContext context) 
    {
        direction = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // get reference to intertactable in rage
        interactObject = collision.gameObject.GetComponent<Interactable>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactObject = null;
    }
}
