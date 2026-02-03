using UnityEngine;

public class Item : Interactable
{
    public override void Interact(Player player)
    {
        if (!canInteract) return;

        // TODO: add item to inventory
        Destroy(this.gameObject);
    }
}
