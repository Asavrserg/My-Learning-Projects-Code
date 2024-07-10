using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize = 10;
    [SerializeField] [Range(0.25f, 30f)] float spawnTimer = 1f;

    private GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    private void EnableObjectInPool()
    {
        for (int j = 0; j < pool.Length; j++)
        {
            if (!pool[j].activeInHierarchy)
            {
                pool[j].SetActive(true);
                return;
            }
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
