using UnityEngine;

public class PackageManager : MonoBehaviour
{

    [SerializeField]
    private GameObject currentTool;

    [SerializeField]
    private GameObject mailObj;

    public GameObject MailObj { get { return mailObj; } }

    public GameObject CurrentTool { get { return currentTool; } set { currentTool = value; } }

    public static PackageManager Instance { get; private set; }

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
