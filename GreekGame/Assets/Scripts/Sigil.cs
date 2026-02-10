using UnityEngine;

public class Sigil : Interactable
{
    // Fields
    [SerializeField]
    private Sprite sprOn;
    [SerializeField]
    private Sprite sprOff;
    [SerializeField]
    private SpriteRenderer sprRenderer;
    [SerializeField]
    private bool isOn;

    public override void Interact(PlayerControlled player)
    {
        if (isOn) sprRenderer.sprite = sprOff;
        else sprRenderer.sprite = sprOn;
        isOn = !isOn;
    }
}
