using UnityEngine;

public class CoinDoor : MonoBehaviour
{

    private DoorController doorController;
    [SerializeField] private int coinNeeded;

    private void Awake()
    {
        doorController = GetComponent<DoorController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameStateManager.instance.coinsChangeEvent.AddListener(AttemptOpenDoor);
    }

    private void AttemptOpenDoor(int coins)
    {
        if (coins >= coinNeeded)
        {
            doorController.Open();
        }
        else
        {
            doorController.Close();
        }
    }
}
