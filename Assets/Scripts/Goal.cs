using UnityEngine;

public class Goal : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameStateManager.instance.CollectGoal(value);
            AudioManager.instance.PlaySFX("CoinGet"); // Play goal sound effect
            GoalSpawner.instance.SpawnGoal(); // Spawn a new goal
            Destroy(gameObject); // Destroy the current goal
        }
    }
}
