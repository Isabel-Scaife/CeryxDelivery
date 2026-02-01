using UnityEngine;

public enum MailState
{
    Sealed,
    Unsealed,
    Closed,
    Opened,
    Resealed,
    Finished
}

public class Mail : MonoBehaviour
{
    [SerializeField]
    private GameObject mailInsidePrefab;
    [SerializeField]
    protected MailState currentState = 0;

    private void FixedUpdate()
    {
        // check if closed, set if it can be opened  
        if(MailState.Closed == currentState)
        {
            Open();
        }

        // check if closed, set if it can be opened  
        if (MailState.Opened == currentState)
        {
            Close();
        }
    }

    /// <summary>
    /// Updates state of the mail
    /// </summary>
    public void UpdateMailState()
    {
        currentState++;

        // run code for next state 
        switch (currentState)
        {
            case MailState.Unsealed: RemoveSeal(); break;
            case MailState.Closed: Open(); break;
            case MailState.Opened: Close(); break;
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

        // update state 
        currentState++;
    }

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

