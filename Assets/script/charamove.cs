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
    public float score;
    public Text ScoreText;
    public Animator animator;
    public int health = 100;
    
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        score=0;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(isGrounded == true){
                rb.AddForce(Vector2.up*JumpForce);
                isGrounded = false;
                animator.SetBool("isJumping", true);
            }
            if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
        }

        if(isAlive){
            score+=Time.deltaTime*4;
            ScoreText.text = Mathf.FloorToInt(score).ToString();;
        }

    }
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("ground")){
            if(isGrounded == false){
                isGrounded = true;
            }
            animator.SetBool("isJumping", false);

        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="enemy"){
            SceneManager.LoadScene("turnbase");
        }
    }

    public void berkurang(int damage){
    health-=damage;
    if(health<=0){
        Die();
    }
   }
   void Die(){
    SceneManager.LoadScene("gameover");
   }
}
