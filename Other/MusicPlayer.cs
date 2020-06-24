using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] musicClips;

    [SerializeField] private bool isPlaying = false;

    AudioSource music;

    private void Awake()
    {
        AwakeFunctions();
    }

    private void AwakeFunctions()
    {
        DontDestroyOnLoad(this);
        music = GetComponent<AudioSource>();
        music.volume = PlayerPrefsController.GetMasterVolume();
    }

    private void Start()
    {
        ChooseSoundTrack();
    }


    private void Update()
    {
        CheckIfAudioIsPlaying();
        ChooseSoundTrack();
    }
    void CheckIfAudioIsPlaying()
    {
        if (music.isPlaying)
        {
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }
    }

    void ChooseSoundTrack()
    {
        if (!isPlaying)
        {
            int index = Random.Range(0, musicClips.Length);

            music.PlayOneShot(musicClips[index]);
        }
    }

    public void SetVolume(float volume)
    {
        music.volume = volume;
    }
}
