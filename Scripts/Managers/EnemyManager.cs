using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField] ObjectPool pool;


    void Start()
    {

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (playerHealth.currHealth.amount <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        GameObject enemy = pool.GetPooledEnemy();
        if (enemy != null)
        {
            enemy.transform.position = spawnPoints[spawnPointIndex].position;
            enemy.transform.rotation = spawnPoints[spawnPointIndex].rotation;
            enemy.SetActive(true);
        }
    }

}
