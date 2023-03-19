using UnityEngine;

public class CollectiblePrefab1 : Collectibles
{
    protected override void OnCollect()
    {
        GameManager.instance.AddScore(10);
    }
}
