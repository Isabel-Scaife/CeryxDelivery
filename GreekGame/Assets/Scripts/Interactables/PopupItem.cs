using UnityEngine;

public class PopupItem : Interactable
{
    // fields
    [SerializeField]
    private Sprite popupSpr;

    // shows popup on canvas when interacted with
    public override void Interact(PlayerControlled player)
    {
        PopupManager.Instance.Show(popupSpr);
    }
}
