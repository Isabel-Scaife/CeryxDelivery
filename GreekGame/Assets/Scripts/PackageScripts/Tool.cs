
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
            Debug.Log("follow");
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
        Debug.Log(isFollowing);
        PackageManager.Instance.CurrentTool = this.gameObject;
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
