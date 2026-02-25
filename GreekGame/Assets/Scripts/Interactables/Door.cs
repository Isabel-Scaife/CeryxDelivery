using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{

    public override void Interact(PlayerControlled player)
    {
        if(!canInteract)
        {
            // sound failed to open

        }
        else
        {
            // open door 

        }
    }

    public void Unlock()
    {
        canInteract = false;
    }
}
