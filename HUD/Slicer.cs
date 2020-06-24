using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    HealthText dealDamage;

    private void Awake()
    {
        dealDamage = FindObjectOfType<HealthText>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        GameObject attacker = other.gameObject;
        int damage = attacker.GetComponent<Attacker>().GetDamageToHealth();

        if (attacker.GetComponent<Attacker>())
        {

            dealDamage.DamageToHealth(damage);

            attacker.GetComponent<Attacker>().DestroyGameObject();
        }
    }
}
