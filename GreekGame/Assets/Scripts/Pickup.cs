using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private bool canInteract = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = true;
    }

}
