using UnityEngine;

public enum MailState
{
    Sealed,
    Unsealed,
    Opened,
    Closed,
    Resealed,
    Finished
}

public class Mail : MonoBehaviour
{
    [SerializeField]
    private GameObject mailInsidePrefab;
    [SerializeField]
    protected MailState currentState = 0;

    /// <summary>
    /// Updates state of the mail, and 
    /// runs code for state change if needed
    /// </summary>
    public void UpdateMailState()
    {
        currentState++;

        // run code for next state 
        switch (currentState)
        {
            case MailState.Unsealed: RemoveSeal(); break;
            //case MailState.Opened: Open(); break;
            //case MailState.Opened: Close(); break;
            case MailState.Resealed: break;
            case MailState.Finished: break;
            default: break;
        }
    }

    /// <summary>
    /// Removes seal from gameobject in scene, 
    /// Updates state of mail
    /// </summary>
    protected void RemoveSeal()
    {
        // add rb to seal 
        GameObject.FindGameObjectWithTag("Seal").AddComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Updates drag
    /// </summary>
    public virtual void Drag() { }

    /// <summary>
    /// Update drag to flase
    /// </summary>
    public virtual void StopDrag() { }

    /// <summary>
    /// Check if mail can be opened,
    /// recieve item inside mail if opened
    /// </summary>
    protected virtual void Open() { }

    /// <summary>
    /// Check if mail can be closed 
    /// </summary>
    protected virtual void Close() { }
}

