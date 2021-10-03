using UnityEngine;

/// <summary>
/// Single item for buying/upgrading pegs/buckets.
/// </summary>
public abstract class ShopItem : MonoBehaviour
{
    public TMPro.TextMeshProUGUI CostText; // Text display for cost of item.
    public TMPro.TextMeshProUGUI DescriptionText; // Text display for description of item.
    public int ItemCost; // Cost of item.
    [TextArea()] public string ItemDescription; // Description of item.

    private void Awake()
    {
        CostText.text = ItemCost.ToString();
        DescriptionText.text = ItemDescription;
    }
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
        ItemEffect();
    }

    protected abstract void ItemEffect();


}
