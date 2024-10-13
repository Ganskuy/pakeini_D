using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musuhtb : MonoBehaviour
{
   public int health = 100;
   public Animator animator;
   public Enemy playercontroller;

   void Start()
   {
    animator = GetComponent<Animator>();
   }
   public void TakeDamage(int damage)
   {
    health-=damage;
    if(health<=0){
        Die();
    }
   }
   void Die()
   {
    SceneManager.LoadScene("2");
   }


public void EAttackanim()
{
    animator.SetTrigger("lempar");
}

public void EEndAttackanim()
{
    if(playercontroller.isAttacking1 == false){
        animator.SetBool("isBeres", true);
    }
}
}


