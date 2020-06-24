using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButton : MonoBehaviour
{
    Color startColor;
    SpriteRenderer sprite;

    [SerializeField] Defender defenderPrefab;

    private void Awake()
    {
        StartFunctions();
        AddCostText();
    }

   private void AddCostText()
    {
        Text costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetManaCost().ToString();
    }

    void StartFunctions()
    {
        sprite = GetComponent<SpriteRenderer>();
        startColor = sprite.color;
    }

    private void OnMouseDown()
    {
        ClickOnMouse();
    }

    private void ClickOnMouse()
    {
        Color white = Color.white;
        var buttons = FindObjectsOfType<PlayerButton>();

        foreach (PlayerButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }

        sprite.color = white;

        FindObjectOfType<PlayerSpawner>().SetDefender(defenderPrefab);
    }
}
