using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    Animator anim;
    Attacker foxAttack;

    private void Awake()
    {
        StartFunctions();
    }

    void StartFunctions()
    {
        anim = GetComponent<Animator>();
        foxAttack = GetComponent<Attacker>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject target = other.gameObject;

        if(other.tag == Tags.TAGS_SCARECROW)
        {
            anim.SetTrigger(Tags.ANIM_TRIGGER_JUMPING);
        }
        else if (target.GetComponent<Defender>())
        {
            foxAttack.Attack(target);
        }

        if (other.GetComponent<Attacker>())
        {
            return;
        }
    }
}
