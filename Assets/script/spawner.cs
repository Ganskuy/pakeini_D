using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;  // Array to hold the 2 different prefabs
    public float spawnRate = 2.0f;  // Time between spawns (in seconds)

    public void OnEnable()
    {
        // Start repeating the spawn method at the specified rate
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    public void OnDisable()
    {
        // Stop the repeating invocation when the object is disabled
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Randomly pick one of the two prefabs from the array
        int randomPrefabIndex = Random.Range(0, prefabs.Length);

        // Spawn the selected prefab at the spawner's position
        GameObject jebakan = Instantiate(prefabs[randomPrefabIndex], transform.position, Quaternion.identity);
    }
}