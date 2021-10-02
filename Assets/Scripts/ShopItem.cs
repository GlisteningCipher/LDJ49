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
    [TextArea()] public string ItemDescription; // Description of item.
    public Transform ItemPosition; // Where new item (usually a peg) will be placed, replaces existing.

    /// <summary>
    /// Checks if player has enough money and buys item if they do.
    /// Is set to 'OnClick' listener.
    /// </summary>
    public void BUTTON_BuyItem()
    {
        if (ScoreKeeper.instance.CurrScore < ItemCost)
        {
            Debug.LogWarning("You don't have enough money to buy!");
            return;
        }
        ScoreKeeper.instance.CurrScore -= ItemCost;
        StartCoroutine(BuyItemCR(ItemPosition, ItemPrefab));
    }

    /// <summary>
    /// Replace existing item with newly bought item.
    /// </summary>
    IEnumerator BuyItemCR(Transform tr, GameObject itemPrefab)
    {
        // Add new object at position
        var go = Instantiate(itemPrefab, tr.parent);
        go.transform.position = tr.position;
        // Remove old object
        Destroy(tr.gameObject);
        yield return null;
        // Remove this shop item.
        Destroy(gameObject);
    }

    private void Awake()
    {
        CostText.text = ItemCost.ToString();
        DescriptionText.text = ItemDescription;
    }
}
