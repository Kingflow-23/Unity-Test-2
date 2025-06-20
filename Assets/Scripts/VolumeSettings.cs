using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        // Initialize sliders with current volume values
        musicSlider.value = AudioManager.instance.musicSource.volume;
        sfxSlider.value = AudioManager.instance.sfxSource.volume;

        // Add listeners for real-time updates
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void SetMusicVolume(float volume)
    {
        AudioManager.instance.musicSource.volume = volume;
    }

    private void SetSFXVolume(float volume)
    {
        AudioManager.instance.sfxSource.volume = volume;
    }
}
