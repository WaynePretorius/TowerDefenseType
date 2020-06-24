using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{

    Attacker fighterAttack;

    private void Awake()
    {
        StartFunction(); 
    }

    private void StartFunction()
    {
        fighterAttack = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject target = other.gameObject;

        if(target.GetComponent<Defender>())
        {
            fighterAttack.Attack(target);
        }

        if (other.GetComponent<Attacker>())
        {
            return;
        }
        
    }

}
