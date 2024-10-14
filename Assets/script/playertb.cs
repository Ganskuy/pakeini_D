using UnityEngine;
using UnityEngine.SceneManagement;

public class playertb : MonoBehaviour
{
    public int health = 100;
    public Animator animator;
    public Player playerController;

    // Reference to healthtbmc for updating the health bar slider
    public healthtbmc healthBar; 

    // SFX References
    public AudioSource audioSource;   // Reference to the AudioSource
    public AudioClip damageSFX;       // The sound effect to play when taking damage

    void Start()
    {
        animator = GetComponent<Animator>();
        
        // Set the initial health slider
        healthBar.SetMaxHealth(health);
    }

    // Method to decrease health when the player takes damage
    public void TakeDamage1(int damage)
    {
        health -= damage;

        // Play the damage sound effect
        audioSource.PlayOneShot(damageSFX);

        // Update the health slider with the current health
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("gameover");
    }

    // Trigger the attack animation
    public void Attackanim()
    {
        animator.SetTrigger("Attack1");
    }

    // Called at the end of the Attack animation to reset to idle
    public void EndAttackanim()
    {
        if (playerController.isAttacking == false)
        {
            animator.SetBool("isIdling", true);
        }
    }
}