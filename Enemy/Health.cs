using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    Attacker attacker;

    private void Awake()
    {
        SetStartFuctions();
    }

    void SetStartFuctions()
    {
        attacker = GetComponent<Attacker>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            attacker.IsAlive(false);
        }

    }
}
