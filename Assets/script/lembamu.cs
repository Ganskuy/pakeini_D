using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lembamu : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int damage = 20;
    void Start()
    {
        rb.velocity = Vector2.left * speed; // Moves left
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        playertb player = hitInfo.GetComponent<playertb>();
        if(player != null){
            player.TakeDamage1(damage);
        }
        Destroy(gameObject);
    }

}
