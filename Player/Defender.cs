using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int manaCost = 50;

    private void Awake()
    {
      manaCost *= Mathf.RoundToInt(PlayerPrefsController.GetDifficulty() / 2);
    }

    public void AddMana(int amount)
    {
        FindObjectOfType<ManaDisplay>().AddMana(amount);
    }

    public int GetManaCost()
    {
        return manaCost;
    }
}
