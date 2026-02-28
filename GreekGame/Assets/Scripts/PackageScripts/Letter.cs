using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class Letter : MonoBehaviour
{

    [SerializeField]
    private float letterDragDist = 80f;
    [SerializeField]
    protected float currentDragDist = 0;
    [SerializeField]
    private bool dragging = false;

    public bool Dragging
    {
        get => dragging;
        set
        {
            dragging = value;
            currentDragDist = 0;
        }
    }


    void Update()
    {
        if (dragging)
        {
            Vector3 worldPos = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit;
            hit = Physics2D.Raycast(worldPos, Vector2.zero, 10.0f, -1, 7f, 7f);

            // letter hit, drag out letter  
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                // update change in mouse y  
                currentDragDist += Mouse.current.delta.ReadValue().y;

                // drag enough to pull out 
                if (currentDragDist >= letterDragDist)
                {
                    Vector3 pos = new Vector3(0, 0, 0);
                    transform.position = pos;
                    // visuals
                    //      letter in front with read/or not option
                    //
                    //      read unflods letters for user
                    //      scroll through letter
                    //      closes when user clicks close option       
                    //
                    //      skip noting happens and letter minigame continues

                    // reset drag
                    currentDragDist = 0;

                }
            }
        }
    }

    public void Raycast()
    {
        dragging = true;
    }

    // open canvas with letter overlay

}
