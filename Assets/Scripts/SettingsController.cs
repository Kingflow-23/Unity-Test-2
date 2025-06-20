using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    private bool isOpen = false;

    void Start()
    {
        settingsPanel.SetActive(false); // Ensure it's hidden on start
    }

    void Update()
    {
        // Toggle with Escape or Return key
        if (Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            ToggleSettings();
        }
    }

    public void ToggleSettings()
    {
        isOpen = !isOpen;
        settingsPanel.SetActive(isOpen);
        
        // Optionally pause/resume game time
        Time.timeScale = isOpen ? 0f : 1f;
    }
}