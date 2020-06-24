using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private Defender defender;
    private GameObject defenderParent;

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(Tags.GAMOBJ_DEFENDER);
        if (!defenderParent)
        {
            defenderParent = new GameObject(Tags.GAMOBJ_DEFENDER);
        }
    }

    private void OnMouseDown()
    {
        if (defender)
        {
            AttemptToSpawnDefender(GetSquareClicked());
        }
        else
        {
            return;
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    public void SetDefender(Defender newDefender)
    {
        defender = newDefender;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        
        return new Vector2(newX, newY);
    }

    private void AttemptToSpawnDefender(Vector2 gridPos)
    {
        var manaDisplay = FindObjectOfType<ManaDisplay>();
        int defenderCost = defender.GetManaCost();

        if (manaDisplay.HaveEnoughMana(defenderCost))
        {
            SpawnDefender(gridPos);
            manaDisplay.RemoveMana(defenderCost);
        }else
        {
            return;
        }
    }

    void SpawnDefender(Vector2 worldPos)
    {
        Defender new1Defender = Instantiate(defender, worldPos, defender.transform.rotation) as Defender;
        new1Defender.transform.parent = defenderParent.transform;
    }
}
