using UnityEngine;
using TMPro;

public class goalDisplay : MonoBehaviour
{
    private TextMeshProUGUI goalText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goalText = GetComponent<TextMeshProUGUI>();
        GameStateManager.instance.goalsChangeEvent.AddListener(UpdateCoinDisplay);
    }

    private void OnDestroy()
    {
        GameStateManager.instance.goalsChangeEvent.RemoveListener(UpdateCoinDisplay);
    }

    private void UpdateCoinDisplay(int coins)
    {
        goalText.text = "Goals: " + coins.ToString("N0");
    }
}
