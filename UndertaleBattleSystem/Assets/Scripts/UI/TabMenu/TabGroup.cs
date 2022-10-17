using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    [SerializeField] private List<TabButton> tabButtons;

    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite highlightedSprite;
    [SerializeField] private Sprite clickedSprite;

    private TabButton seletedTab;

    private void Awake()
    {
        seletedTab = tabButtons[0];
    }

    private void OnEnable()
    {
        BattleHandler.OnPlayerTurn += PositionPlayer;
    }

    private void OnDisable()
    {
        BattleHandler.OnPlayerTurn += PositionPlayer;
    }

    private void Start()
    {
        ResetTabsSprite();

        tabButtons[0].EnableTabContent();
        SetTabSprite(tabButtons[0], clickedSprite);
    }

    public void AddTabButton(TabButton tabButton)
    {
        tabButtons.Add(tabButton);
    }

    public void OnTabEnter(TabButton tabButton)
    {
        ResetUnselectedTabsSprite();

        if (!tabButton.IsSelected)
            SetTabSprite(tabButton, highlightedSprite);
    }

    public void OnTabSelected(TabButton tabButton)
    {
        ResetTabsSprite();
        DisableAllTabs();
        SetTabSprite(tabButton, clickedSprite);

        seletedTab = tabButton;
        seletedTab.EnableTabContent();
    }

    public void OnTabExit(TabButton tabButton)
    {
        ResetUnselectedTabsSprite();
    }

    private void PositionPlayer()
    {
        seletedTab.PositionPlayer();
    }

    private void SetTabSprite(TabButton tabButton, Sprite sprite)
    {
        tabButton.TabImage.sprite = sprite;
    }

    private void ResetTabsSprite()
    {
        foreach (TabButton tabButton in tabButtons)
        {
            tabButton.TabImage.sprite = defaultSprite;
        }
    }

    private void ResetUnselectedTabsSprite()
    {
        foreach (TabButton tabButton in tabButtons)
        {
            if (tabButton.IsSelected) continue;

            tabButton.TabImage.sprite = defaultSprite;
        }
    }

    public void DisableAllTabs()
    {
        foreach (TabButton tabButton in tabButtons)
        {
            tabButton.DisableTabContent();
        }
    }

    public void EnableButtonsInteraction()
    {
        foreach (TabButton tabButton in tabButtons)
        {
            tabButton.IsInteractable = true;
        }
    }

    public void DisableButtonsInteraction()
    {
        foreach (TabButton tabButton in tabButtons)
        {
            tabButton.IsInteractable = false;
        }
    }
}