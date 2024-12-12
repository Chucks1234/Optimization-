using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //public static ObjectPool SharedInstance;
    //Manage Enemies
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyAmount;

    List<GameObject> pooledEnemies;

    private void Awake()
    {
        
    }

    private void Start()
    {
        pooledEnemies = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < enemyAmount; i++)
        {
            tmp = Instantiate(enemyPrefab);
            tmp.SetActive(false);
            pooledEnemies.Add(tmp);
        }

    }

    public GameObject GetPooledEnemy()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            if (!pooledEnemies[i].activeInHierarchy)
            {
                return pooledEnemies[i];
            }
        }
        return null;
    }
}
