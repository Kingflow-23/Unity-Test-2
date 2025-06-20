using UnityEngine;

public class GoalSpawner : MonoBehaviour
{

    [SerializeField] private GameObject goalPrefab; // Assign your goal prefab in the inspector
    public static GoalSpawner instance; // Singleton instance

    // Spawn area boundaries
    private Vector3 minBounds = new Vector3(-4f, 0.5f, 0f);
    private Vector3 maxBounds = new Vector3(4f, 0.5f, 9f);

    private void Awake()
    {
        instance = this; // Set the singleton instance
    }

    void Start()
    {
        SpawnGoal();
    }

    public void SpawnGoal()
    {
        float x = Random.Range(minBounds.x, maxBounds.x);
        float z = Random.Range(minBounds.z, maxBounds.z);
        float y = minBounds.y; // Keep Y constant at 0.5

        Vector3 spawnPosition = new Vector3(x, y, z);
        Instantiate(goalPrefab, spawnPosition, Quaternion.identity);
    }
}