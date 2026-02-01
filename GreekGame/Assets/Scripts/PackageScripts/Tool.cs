
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tool : MonoBehaviour
{

    [SerializeField]
    private Vector2 mousePos;

    private bool isFollowing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            Follow();
        }
    }

    /// <summary>
    /// Performs tools designate action when the user clicks
    /// </summary>
    public virtual void Use() { }

    /// <summary>
    /// Updates the current tool in package manager
    /// </summary>
    public void SelectTool() 
    {
        Debug.Log("Pickuped Up tool");
        isFollowing = true;

        // change objects depth to be on top 
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        PackageManager.Instance.CurrentTool = this.gameObject;
    }

    /// <summary>
    /// Updates the current tool in package manager
    /// </summary>
    public void DropTool()
    {
        Debug.Log("Dropped tool");
        isFollowing = false;

        // change objects depth to orginal value
        Vector3 pos = transform.position;
        pos.z = 1;
        transform.position = pos;

        PackageManager.Instance.CurrentTool = null;
    }

    /// <summary>
    /// Current tool follows mouse position
    /// </summary>
    private void Follow()
    {
        mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = (Vector2)Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPos;
    }
}
