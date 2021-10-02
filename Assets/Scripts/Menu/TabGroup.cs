using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public List<GameObject> objectsToSwap;

    TabButton selectedTab;

    void OnEnable()
    {
        if (tabButtons == null) tabButtons = new List<TabButton>();
        if (tabButtons.Count > 0) OnTabSelected(tabButtons[0]);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (button != selectedTab)
            button.background.sprite = tabHover;
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        button.background.sprite = tabActive;
        ResetTabs();
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; ++i)
        {
            objectsToSwap[i]?.SetActive(i == index);
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (button == selectedTab) continue;
            button.background.sprite = tabIdle;
        }
    }
}
