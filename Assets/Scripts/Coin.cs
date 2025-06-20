using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameStateManager.instance.CollectCoin(value);
            Destroy(gameObject); // Destroy the coin after collection
            AudioManager.instance.PlaySFX("CoinGet"); // Play coin sound effect
        }
    }
    
}
