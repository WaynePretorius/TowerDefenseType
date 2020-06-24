using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour
{
    [SerializeField] Slider volumeController;
    [SerializeField] Slider difficultySlider;

    [SerializeField] float defVolume = 0.5f;
    [SerializeField] float defaultDifficulty = 1f;

    private void Start()
    {
        volumeController.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        VolumeSlider();
    }
    void VolumeSlider()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer) 
        {
            musicPlayer.SetVolume(volumeController.value);
        }
        else
        {
            Debug.LogWarning("No musicplayer, start from splash");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeController.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<SplashScreen>().StartScreen();
    }

    public void SetDefault()
    {
        volumeController.value = defVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
