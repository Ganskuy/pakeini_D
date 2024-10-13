using UnityEngine;
using UnityEngine.SceneManagement;

public class playertb : MonoBehaviour
{
    public int health = 100;
    public Animator animator;
    public Player playerController; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage1(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("gameover");
    }

    public void Attackanim()
    {
        // Trigger the attack animation
        animator.SetTrigger("Attack1");
    }

    // This method can be called from an Animation Event at the end of the Attack animation
    public void EndAttackanim()
    {
        // Set isIdling to true when isAttacking is false
        if (playerController.isAttacking == false)
        {
            animator.SetBool("isIdling", true); 
        }
    }
}