using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{

    bool damaged;


    public AudioClip deathClip;


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;

    public HealthData maxHealth;
    public HealthData currHealth;
    public HealthUI healthUI;

    bool isDead;

    int id_die = Animator.StringToHash("Die");

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();

        //startingHealth for Our character;
        currHealth.amount = maxHealth.amount;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currHealth.amount -= amount;
        healthUI.healthSlider.value = currHealth.amount;

        playerAudio.Play();

        if (currHealth.amount <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();

        anim.SetTrigger(id_die);

        playerAudio.clip = deathClip;
        playerAudio.Play();
        //When player is dead
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    public void RestartLevel()
    {  //When it is game over
        SceneManager.LoadScene(0);
    }

}
