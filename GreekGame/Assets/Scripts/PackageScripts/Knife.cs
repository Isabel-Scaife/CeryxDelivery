using UnityEngine;
using UnityEngine.InputSystem;

public class Knife : Tool
{
    [SerializeField]
    private float sealDragDist = -2.5f;
    [SerializeField]
    private float currentDragDist = 0;

    private bool dragging = false;
    private bool sealCut = false;

    // look into trail render for slice 

    protected override void Update()
    {
        // cuts selected object if clicking
        if (dragging)
        {
            if(!sealCut)
            {
                UpdateDrag();
                CutSeal();
            }
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

            sealCut = true;
        }
    }

    private void UpdateDrag()
    {
        // if mouse clicked down track y 
        currentDragDist += Mouse.current.delta.ReadValue().y;
    }

}
