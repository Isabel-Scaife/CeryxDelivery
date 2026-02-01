using UnityEngine;
using UnityEngine.InputSystem;


public class Letter : Mail
{

    [SerializeField]
    private float letterDragDist = 80f;
    private float currentDragDist = 0;
    private bool dragging = false;

    /// <summary>
    /// If drag distance met open letter, 
    /// recieve letter inside 
    /// </summary>
    protected override void Open()
    {
        if (currentDragDist >= letterDragDist)
        {
            UpdateMailState();
            currentDragDist = 0;

            // give player mail inside 
        }
    }

    /// <summary>
    /// If drag distance met close letter
    /// </summary>
    protected override void Close()
    {
        if (currentDragDist <= (-1*letterDragDist))
        {
            UpdateMailState();
            currentDragDist = 0;
        }
    }

    private void UpdateDrag()
    {
        // if mouse clicked down track y 
        currentDragDist += Mouse.current.delta.ReadValue().y;
    }

    // method to remove seal, may be moved to knife use  
    //      check if holding knife
    //      check if clicked and dragged
    //      similar to how open/closing letter works 

    // method to add seal, may be moved to seal use  
    //      check if holding wax sealer
    //      ckeck if clicked if right spot
    //      

    // look into trail render for slice 
}
