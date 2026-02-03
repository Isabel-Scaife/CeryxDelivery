using UnityEngine;

/// <summary>
/// Anything the player can interact with in the overworld
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    protected bool canInteract;
    public abstract void Interact(Player player);
}