using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI youWinMessage;
    [SerializeField] private TextMeshProUGUI gameOverMessage;
    [SerializeField] private Transform playerTransform;

    private Vector3 minBounds = new Vector3(-5f, 1f, -15f);
    private Vector3 maxBounds = new Vector3(5f, 1f, 15f);

    private bool gameEnded = false;

    void Start()
    {
        youWinMessage.gameObject.SetActive(false);
        gameOverMessage.gameObject.SetActive(false);

        AudioManager.instance.PlayMusic("MainTheme");
    }

    void Update()
    {
        if (gameEnded) return;

        Vector3 pos = playerTransform.position;

        if (pos.x < minBounds.x || pos.x > maxBounds.x || pos.z < minBounds.z || pos.z > maxBounds.z)
        {
            ShowGameOver();
        }
    }

    private void ShowWin()
    {
        youWinMessage.gameObject.SetActive(true);
        gameEnded = true;
        AudioManager.instance.PlaySFX("EpicWin");
        AudioManager.instance.musicSource.Stop(); 
        Invoke(nameof(RestartGame), 3f);
    }

    private void ShowGameOver()
    {
        gameOverMessage.gameObject.SetActive(true);
        gameEnded = true;
        AudioManager.instance.PlaySFX("Loss");
        AudioManager.instance.musicSource.Stop(); 
        Invoke(nameof(RestartGame), 3f);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameEnded) return;

        if (other.CompareTag("End"))
        {
            ShowWin();
        }
    }
}
