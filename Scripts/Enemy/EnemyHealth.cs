using UnityEngine;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    NavMeshAgent navMeshAgent;
    Rigidbody rb;

    ScoreManager scoreManager;
    bool isDead;
    bool isSinking;

    int id_dead = Animator.StringToHash("Dead");

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        scoreManager = FindObjectOfType<ScoreManager>();
        currentHealth = startingHealth;
    }


    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        enemyAudio.Play();

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger(id_dead);

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }


    public void StartSinking()
    {
        navMeshAgent.enabled = false;
        rb.isKinematic = true;
        isSinking = true;
        scoreManager.scoreData.amount += scoreValue;
        //Destroy(gameObject, 2f);
        gameObject.SetActive(false);
    }
}
