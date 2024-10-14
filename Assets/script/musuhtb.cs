using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musuhtb : MonoBehaviour
{
    public int health = 100;
    public Animator animator;
    public Enemy playercontroller;

    // Reference to healthtbmusuh for updating the health slider
    public healthtbmusuh healthBar; // Link this in the Unity inspector

    void Start()
    {
        animator = GetComponent<Animator>();

        // Set the max health for the slider at the start of the game
        healthBar.SetMaxHealth(health);
    }

    // Method to decrease health when the enemy takes damage
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Update the health slider whenever health changes
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("lari"); // Change "2" to the scene name you want to load
    }

    // Trigger the enemy's attack animation
    public void EAttackanim()
    {
        animator.SetTrigger("lempar");
    }

    // Called at the end of the attack animation to set isBeres to true
    public void EEndAttackanim()
    {
        if (playercontroller.isAttacking1 == false)
        {
            animator.SetBool("isBeres", true);
        }
    }
}