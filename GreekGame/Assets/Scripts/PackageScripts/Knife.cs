using UnityEngine;
using UnityEngine.InputSystem;

public class Knife : Tool
{
    [SerializeField]
    private float sealDragDist = -2.5f;
    [SerializeField]
    private float currentDragDist = 0;

    private bool dragging = false;

    // look into trail render for slice 

    // method to remove seal, may be moved to knife use  
    //      check if holding knife
    //      check if clicked and dragged
    //      similar to how open/closing letter works 


    protected override void Update()
    {
        // cuts selected object if clicking
        if (dragging)
        {
            UpdateDrag();
            CutSeal();
        }

        base.Update();
    }

    /// <summary>
    /// Beign using knife, starts tracking knife drag 
    /// </summary>
    public override void Use() 
    {
        dragging = true;
    }

    public override void ResetUse()
    {
        // resest drag info
        currentDragDist = 0;
        dragging = false;
    }

    private void CutSeal()
    {
        if (currentDragDist <= sealDragDist)
        {
            // remove seal 
            Debug.Log("Removed Seal");

            // update mail state
            GameObject mail = PackageManager.Instance.MailObj;

            if (mail != null)
            {
                mail.GetComponent<Mail>().UpdateMailState();
            }

            ResetUse();
        }
    }

    private void UpdateDrag()
    {
        // if mouse clicked down track y 
        currentDragDist += Mouse.current.delta.ReadValue().y;
    }

}
