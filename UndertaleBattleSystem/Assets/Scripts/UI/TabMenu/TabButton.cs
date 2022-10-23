using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Tap Button Components")]
    [SerializeField] private TabGroup tabGroup;
    [SerializeField] private GameObject content;

    public Image TabImage;

    [Header("Player Fields")]
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Vector2 playerPosition;

    public bool IsSelected { get; private set; }
    public bool IsInteractable = true;

    public UnityEvent OnTabEnabled;
    public UnityEvent OnTapDisabled;

    private void Awake()
    {
        DisableTabContent();
        tabGroup.AddTabButton(this);
    }

    public void EnableTabContent()
    {
        IsSelected = true;

        content.SetActive(true);
        OnTabEnabled?.Invoke();
    }

    public void DisableTabContent()
    {
        IsSelected = false;

        content.SetActive(false);
        OnTapDisabled?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!IsInteractable) return;

        PositionPlayer();
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    public void PositionPlayer()
    {
        player.SetPlayerPosition(playerPosition);
    }
}