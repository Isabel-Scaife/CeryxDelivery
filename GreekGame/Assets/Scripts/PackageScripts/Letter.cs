using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField]
    private float letterDragDistance = 2.5f;

    [SerializeField]
    private float sealDragDistance = 2.5f;

    private bool isOpen = false;

    // method to open letter 
    //      check if empty hand
    //      check if clicked and dragged
    //      track starting y postion, once a certain y distance is passed the letter opens
    //      add click zone to letter, to start this method player must be within zone 

    // method to close letter
    //      check if empty hand
    //      check if clicked and dragged 
    //      track starting y postion, once a certain y distance is passed the letter opens
    //      add click zone to letter, to start this method player must be within zone 

    // method to remove seal, may be moved to knife use  
    //      check if holding knife
    //      check if clicked and dragged
    //      similar to how open/closing letter works 

    // method to add seal, may be moved to seal use  
    //      check if holding wax sealer
    //      ckeck if clicked if right spot 
}
