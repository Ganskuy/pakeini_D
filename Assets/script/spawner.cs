using UnityEngine;

public class spawner : MonoBehaviour
{
   public GameObject prefab;
   public float spawnrate;

   public void OnEnable(){
    InvokeRepeating(nameof(Spawn), spawnrate, spawnrate);
   }

   public void OnDisable(){
    CancelInvoke(nameof(Spawn));
   }

   private void Spawn(){
    GameObject jebakan = Instantiate(prefab, transform.position, Quaternion.identity);
   }
}
