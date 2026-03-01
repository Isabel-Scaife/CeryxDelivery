using UnityEngine;
using UnityEngine.InputSystem;

public class PopupManager : MonoBehaviour
{
    // singleton
    public static PopupManager Instance;

    // fields
    [SerializeField]
    private SpriteRenderer sprRenderer;
    [SerializeField]
    private PlayerInput popupInput;
    [SerializeField]
    private PlayerControlled player;

    private void Awake()
    {
        Instance = this;
    }

    // switches input controls and sprite and shows, then hides upon input
    public void Show(Sprite spr)
    {
        //player.PauseInputControls();
        sprRenderer.sprite = spr;
    }
}
