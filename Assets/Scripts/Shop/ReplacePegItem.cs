using UnityEngine;

public class ReplacePegItem : ShopItem
{
    public GameObject seesawPrefab;

    /// <summary>
    /// Replace existing item with newly bought item.
    /// </summary>
    protected override void ItemEffect()
    {
        GameObject[] pegs = GameObject.FindGameObjectsWithTag("Peg");
        GameObject randomPeg = pegs[Random.Range(0, pegs.Length)];
        // Add new object at position
        var go = Instantiate(seesawPrefab, randomPeg.transform.parent);
        go.transform.position = randomPeg.transform.position;
        // Remove old object
        Destroy(randomPeg);
    }
}
