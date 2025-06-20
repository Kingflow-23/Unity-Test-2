using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    private int coins;
    private int goals;

    public UnityEvent<int> coinsChangeEvent = new UnityEvent<int>();
    public UnityEvent<int> goalsChangeEvent = new UnityEvent<int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            coins = 0; // Initialize coins to 0 or any starting value
            coinsChangeEvent.Invoke(coins); // Initialize the event with the starting coin count
            goals = 0; // Initialize goals to 0 or any starting value
            goalsChangeEvent.Invoke(goals); // Initialize the event with the starting goal count
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize game state variables here if needed
        coins = 0;
        coinsChangeEvent.Invoke(coins); // Initialize the event with the starting coin count

        goals = 0;
        goalsChangeEvent.Invoke(goals); // Initialize the event with the starting goal count
    }

    public void CollectCoin(int value)
    {
        coins += value;
        coinsChangeEvent.Invoke(coins); // Notify listeners about the coin change
    }

    public void CollectGoal(int value)
    {
        goals += value;
        goalsChangeEvent.Invoke(goals); // Notify listeners about the goal change
    }
}
