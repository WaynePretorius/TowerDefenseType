using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaDisplay : MonoBehaviour
{
    [SerializeField] private int mana = 300;

    private Text manaText;

    private void Awake()
    {
        ChangeDifficulty(PlayerPrefsController.GetDifficulty());
    }

    private void Start()
    {
        StartFunctions();
        DisplayText();   
    }

    private void ChangeDifficulty(float difficulty)
    {
        mana = mana * 2 / Mathf.RoundToInt(difficulty);
    }

    private void StartFunctions()
    {
        manaText = GetComponent<Text>();
        
    }

    private void DisplayText()
    {
        manaText.text = mana.ToString();
    }

    public void AddMana(int amount)
    {
        mana += amount;
        DisplayText();
    }

    public void RemoveMana(int amount)
    {
        if (mana >= amount)
        {
            mana -= amount;
            DisplayText();
        }
    }

    public bool HaveEnoughMana(int amount)
    {
        return mana >= amount;
    }
}
