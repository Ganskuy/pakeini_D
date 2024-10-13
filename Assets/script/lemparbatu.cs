using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemparbatu : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int damage = 20;
    void Start()
    {
        rb.velocity = transform.right*speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        musuhtb musuh = hitInfo.GetComponent<musuhtb>();
        if(musuh != null){
            musuh.TakeDamage(damage);
        }
        Destroy(gameObject);

    }

}
