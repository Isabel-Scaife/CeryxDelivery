using UnityEngine;

public enum ToolType
{
    None, 
    Kinfe,
    Seal
}

public class PackageManager : MonoBehaviour
{

    [SerializeField]
    private Tool currentTool;
    [SerializeField]
    private ToolType toolType;
    [SerializeField]
    private GameObject mailObj;

    public static PackageManager Instance { get; private set; }
    public Tool CurrentTool { get => currentTool; set => currentTool = value; }

    public GameObject MailObj { get { return mailObj; } }

    private void Awake()
    {
        if (Instance!= null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
