using System.Collections;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private GameObject _prefab1;
    [SerializeField] private GameObject _prefab2;
    private float _spawnRate1 = 4f;
    private float _spawnRate2 = 4f;

    public GameObject Prefab1
    {
        get { return _prefab1; }
        set { _prefab1 = value; }
    }

    public GameObject Prefab2
    {
        get { return _prefab2; }
        set { _prefab2 = value; }
    }

    public float SpawnRate1
    {
        get { return _spawnRate1; }
        set { _spawnRate1 = value; }
    }

    public float SpawnRate2
    {
        get { return _spawnRate2; }
        set { _spawnRate2 = value; }
    }

    private void Start()
    {
        StartCoroutine(SpawnCollectibles());
    }

    private IEnumerator SpawnCollectibles()
    {
        while (true)
        {
            Spawn(_prefab1);
            yield return new WaitForSeconds(_spawnRate1);

            Spawn(_prefab2);
            yield return new WaitForSeconds(_spawnRate2);
        }
    }

    private void Spawn(GameObject prefabToSpawn)
    {
        float spawnPosX = Random.Range(-45f, 45f);
        float spawnPosZ = Random.Range(-45f, 45f);
        Vector3 spawnPosition = new Vector3(spawnPosX, 0.5f, spawnPosZ);

        GameObject instance = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        if (prefabToSpawn == _prefab1)
        {
            instance.AddComponent<CollectiblePrefab1>();
        }
        else if (prefabToSpawn == _prefab2)
        {
            instance.AddComponent<CollectiblePrefab2>();
        }
    }

    protected virtual void OnCollect()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollect();
            Destroy(gameObject);
        }
    }
}
