using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Single item for buying/upgrading pegs/buckets.
/// </summary>
public class ShopItem : MonoBehaviour
{
    public Button MyButton => GetComponentInChildren<Button>();
    public TMPro.TextMeshProUGUI CostText; // Text display for cost of item.
    public TMPro.TextMeshProUGUI DescriptionText; // Text display for description of item.
    public GameObject ItemPrefab; // Prefab of item you buy.
    public int ItemCost; // Cost of item.

    /// <summary>
    /// Checks if player has enough money and buys item if they do.
    /// Is set to 'OnClick' listener.
    /// </summary>
    public void BUTTON_BuyItem()
    {
        // TODO: Check player ball count.
        Debug.Log("Buying item:" + ItemPrefab.name);
    }

    private void Awake()
    {
        CostText.text = ItemCost.ToString();
    }
}
