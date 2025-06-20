using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{

    private TextMeshProUGUI coinText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        GameStateManager.instance.coinsChangeEvent.AddListener(UpdateCoinDisplay);
    }

    private void OnDestroy()
    {
        GameStateManager.instance.coinsChangeEvent.RemoveListener(UpdateCoinDisplay);
    }

    private void UpdateCoinDisplay(int coins)
    {
        coinText.text = "Coins: " + coins.ToString("N0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
