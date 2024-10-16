using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class charamove : MonoBehaviour
{
    public float JumpForce;
    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;
    Rigidbody2D rb;
    public static float score = 0;  // Static variable to persist the score
    public Text ScoreText;
    public Text HighScoreText;  // Display the highest score
    public Animator animator;
    public int health = 100;

    // Reference to healthrun script to control health bar
    public healthrun healthBar;

    // AudioSource to play sound effects
    public AudioSource audioSource;

    // SFX for jumping and running
    public AudioClip runSFX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Set max health when the game starts
        healthBar.SetMaxHealth(health);

        // Display the highest score on UI when the game starts
        DisplayHighScore();
    }

    void Update()
    {
        // Detect jump input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Detect running or movement input (if grounded)
        if (isGrounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            // Play running sound when moving
            if (!audioSource.isPlaying || audioSource.clip != runSFX)
            {
                audioSource.clip = runSFX;
                audioSource.Play();
            }
        }
        // Stop running sound when not moving or jumping
        else if (isGrounded && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && audioSource.clip == runSFX)
        {
            audioSource.Stop();
        }

        // Only update score when alive
        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreText.text = Mathf.FloorToInt(score).ToString();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * JumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
                animator.SetBool("isJumping", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            // Save the score before transitioning to the next scene
            SaveHighScore();
            SceneManager.LoadScene("turnbase");
        }
    }

    public void berkurang(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }

        // Update the health bar based on the new health value
        healthBar.SetHealth(health);
    }

    void Die()
    {
        // Save the score before transitioning to the game over scene
        SaveHighScore();
        SceneManager.LoadScene("gameover");
    }

    // Call this method when going to the Main Menu or retrying the game
    public static void ResetScore()
    {
        score = 0;
    }

    // Save the player's highest score using PlayerPrefs
    void SaveHighScore()
    {
        int currentScore = Mathf.FloorToInt(score);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Check if the current score is higher than the saved high score
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);  // Save the new high score
            PlayerPrefs.Save();  // Ensure it gets written to storage
        }
    }

    // Display the highest score on the UI
    void DisplayHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (HighScoreText != null)
        {
            HighScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}