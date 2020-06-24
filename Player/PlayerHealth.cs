using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    private Defender defender;
    private Animator animato;

    private void Awake()
    {
        SetStartFuctions();
    }

    void SetStartFuctions()
    {
        defender = GetComponent<Defender>();
        animato = GetComponent<Animator>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            animato.SetBool(Tags.ANIM_ISDEAD,true);
        }

    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
