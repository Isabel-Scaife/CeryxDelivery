using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // components on player
    private Rigidbody2D rg; 

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
        if(context.performed)
        {
            
        }
    }

    public void Move (InputAction.CallbackContext context) 
    {
        direction = context.ReadValue<Vector2>();
    }
}
