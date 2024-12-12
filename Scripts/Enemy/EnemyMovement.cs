using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navMeshAgent;
    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;

    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {

        if (enemyHealth.currentHealth > 0 && playerHealth.currHealth.amount > 0)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }
}
