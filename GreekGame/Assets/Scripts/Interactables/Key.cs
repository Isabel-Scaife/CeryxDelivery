using UnityEngine;

public class Key : Interactable
{
    [SerializeField]
    private Door door;

    public override void Interact(PlayerControlled player)
    {
        // place object in bird inventory
        if (player is Bird)
        {
            Bird bird = (Bird)player;

            if(bird.Pickup(this.gameObject))
            {
                this.transform.SetParent(bird.transform);
            }
        }
        // destory key
        if (player is Player)
        {
            Debug.Log("player picks up key");
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Unlock door that corresponds
    /// </summary>
    private void OnDestroy()
    {
        door.Unlock();
    }
}
