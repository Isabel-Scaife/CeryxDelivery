using UnityEngine;
using UnityEngine.InputSystem;


public class Letter : Mail
{

    [SerializeField]
    private float letterDragDist = 80f;
    private float currentDragDist = 0;
    private bool dragging = false;

    protected void FixedUpdate()
    {
        // cuts selected object if clicking
        if (dragging)
        {
            UpdateDrag();

            // check if letter can be opened
            if (currentState == MailState.Closed)
            {
                Open();
            }
            // check if letter can be closed
            else if (currentState == MailState.Opened)
            {
                Close();
            }
        }
    }

    /// <summary>
    /// If drag distance met open letter, 
    /// recieve letter inside 
    /// </summary>
    protected override void Open()
    {
        if (currentDragDist >= letterDragDist)
        {
            // close letter
            Debug.Log("Opened letter");

            // update state
            UpdateMailState();

            // update visuals of letter

            currentDragDist = 0;

            // get mail from letter

        }
    }

    /// <summary>
    /// If drag distance met close letter
    /// </summary>
    protected override void Close()
    {
        if (currentDragDist <=(-1*letterDragDist))
        {
            // close letter
            Debug.Log("Closed letter");

            // update state
            UpdateMailState();

            // update visuals of letter

            currentDragDist = 0;
        }
    }

    private void UpdateDrag()
    {
        // if mouse clicked down track y 
        currentDragDist += Mouse.current.delta.ReadValue().y;
    }

    public override void Drag()
    {
        dragging = true;
    }  

    public override void StopDrag()
    {
        dragging = false;
    }


    // method to add seal, may be moved to seal use  
    //      check if holding wax sealer
    //      ckeck if clicked if right spot
    //      

    // look into trail render for slice 
}
