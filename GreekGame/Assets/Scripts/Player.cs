using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    // components on player
    private Rigidbody2D rg;

    // interactions 
    [SerializeField]
    private List<string> tags = new List<string>();
    [SerializeField]
    private string interactTag;
    private GameObject interactObject = null;

    // movement
    [SerializeField]
    private float speed;
    private Vector2 direction;
    private Vector2 velocity;
    private Vector2 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        // update player's position
        velocity = direction * speed;
        position = (Vector2)transform.position + velocity * Time.fixedDeltaTime;
        rg.MovePosition(position);

    }

    public void Interact (InputAction.CallbackContext context)
    {
        // interact with item if something is within range
        if(context.started)
        {

            if(interactTag == tags[0])
            {
                // call item script 
                interactObject.GetComponent<Interactable>().Interact(this);

                // reset current interact info
                interactObject = null;
                interactTag = null;
                Debug.Log("Item Pickuped up");
            }
            else if (interactTag == tags[1])
            {
                // call door script 

                // reset current interact info
                interactObject = null;
                interactTag = null;
                interactTag = null;
            }
            else if (interactTag == tags[2])
            {
                // call interact on the NPC
                interactObject.GetComponent<Interactable>().Interact(this);

                // reset current interact info
                interactObject = null;
                interactTag = null;
                Debug.Log("NPC talked to");
            }
        }
    }

    public void Move (InputAction.CallbackContext context) 
    {
        direction = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // get reference to intertactable inrage
        interactObject = collision.gameObject;
        interactTag =  collision.gameObject.tag;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactObject = null;
        interactTag = null;
    }
}
