using UnityEngine;

public class CollectiblePrefab2 : Collectibles
{
    protected override void OnCollect()
    {
        GameManager.instance.AddScore(5);
    }
}
