using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] SplashScreen levelloader;

    private int hpAmount = 40;

    private void Awake()
    {
        Inititialize();
    }

    private void Inititialize()
    {
        hpText = GetComponent<Text>();
        levelloader = FindObjectOfType< SplashScreen>();
        ChangeDifficulty(PlayerPrefsController.GetDifficulty());
    }

    private void ChangeDifficulty(float difficulty)
    {
        hpAmount /= Mathf.RoundToInt(difficulty);
    }

    private void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        hpText.text = hpAmount.ToString();

        if (hpAmount <= 0)
        {
            levelloader.GameOver();
        }
    }

    public void DamageToHealth(int damage)
    {
        hpAmount -= damage;
    }
}
