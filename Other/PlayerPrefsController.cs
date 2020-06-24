using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const float MIN_VALUE = 0f;
    const float MAX_VALUE = 1f;

    const float MIN_DIFFI = 0f;
    const float MAX_DIFF = 4f;

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VALUE && volume <= MAX_VALUE)
        {
            PlayerPrefs.SetFloat(Tags.MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of bounds");
        }
    }

    public static float GetMasterVolume()
    {
        float volume = PlayerPrefs.GetFloat(Tags.MASTER_VOLUME_KEY);

        return volume;
    }

    public static void SetDifficulty(float number)
    {
        if(number >= MIN_DIFFI  && number <= MAX_DIFF)
        {
            PlayerPrefs.SetFloat(Tags.DIFFICULTY_KEY, number);
        }
        else
        {
            Debug.LogError("Difficulty out of bounds");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(Tags.DIFFICULTY_KEY);
    }
        
}
