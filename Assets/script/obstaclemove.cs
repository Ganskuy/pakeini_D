using UnityEngine;

public class obstaclemove : MonoBehaviour
{
    public float speed;
    private float leftEdge;
    public int damage = 20;

    private void Start(){
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update(){
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        // Check if the object collided with the player
        if (col.CompareTag("player")){
            // Get the charamove component from the player
            charamove player = col.GetComponent<charamove>();
            if (player != null){
                // Call the method to decrease health and pass the obstacle's damage
                player.berkurang(damage);
            }
            // Destroy the obstacle after it hits the player
            Destroy(gameObject);
        }
    }
}

