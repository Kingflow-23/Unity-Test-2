using UnityEngine;

public class GoalDoor : MonoBehaviour
{
    private DoorController doorController;
    [SerializeField] private int goalNeeded;

    private void Awake()
    {
        doorController = GetComponent<DoorController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameStateManager.instance.goalsChangeEvent.AddListener(AttemptOpenDoor);
    }

    private void AttemptOpenDoor(int coins)
    {
        if (coins >= goalNeeded)
        {
            doorController.Open();
        }
        else
        {
            doorController.Close();
        }
    }
}
