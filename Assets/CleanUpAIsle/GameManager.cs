using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject puddlePrefab; // Reference to the puddle prefab
    public int minPuddles = 5; // Minimum number of puddles to spawn
    public int maxPuddles = 10; // Maximum number of puddles to spawn
    public Vector3 spawnAreaMin; // Minimum bounds for puddle spawning
    public Vector3 spawnAreaMax; // Maximum bounds for puddle spawning

    private int contactCount = 0;

    void Start()
    {
        // Subscribe to the collision events of the player's collider
        PlayerCollision.OnCollisionEnterEvent += OnCollisionEnterHandler;

        // Spawn puddles at the start of the game
        SpawnPuddles();
    }

    void OnDestroy()
    {
        // Unsubscribe from collision events when the GameManager is destroyed
        PlayerCollision.OnCollisionEnterEvent -= OnCollisionEnterHandler;
    }

    void OnCollisionEnterHandler(Collision collision)
    {
        if (collision.gameObject.CompareTag("Puddle"))
        {
            // Increment the contact count whenever the player's collider makes contact with a puddle
            contactCount++;
            Debug.Log("Contact Count: " + contactCount);

            // Destroy the puddle to simulate cleaning
            Destroy(collision.gameObject);
        }
    }

    void SpawnPuddles()
    {
        int puddleCount = Random.Range(minPuddles, maxPuddles);

        for (int i = 0; i < puddleCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                spawnAreaMin.y,
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            Instantiate(puddlePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
