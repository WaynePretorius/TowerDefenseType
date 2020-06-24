using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float currentSpeed = 0f;

    private GameObject currentTarget;

    [SerializeField] private int damageToHealth = 1;

    public int GetDamageToHealth()
    {
        return damageToHealth;
    }

    bool isAlive = true;
    
    public bool IsAlive(bool live)
    {
        isAlive = live;

        return isAlive;
    }

    private Animator anim;
    private LevelController levelController;

    private void Awake()
    {
        StartFunctions();
        levelController.IncreaseNumberofAttackers();
    }

    void StartFunctions()
    {
        anim = GetComponent<Animator>();
        levelController = FindObjectOfType<LevelController>();
    }

    void Update()
    {
        Death();
        WalkLeft();
        AnimationStates();
    }                                               //Update

    private void WalkLeft()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetCurrentSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void Death()
    {
        if (!isAlive)
        {
            anim.Play(Tags.ANIM_DEATH);
        }
    }

    public void DestroyGameObject()
    {
        levelController.AttackersDestroyed();
        Destroy(gameObject);
    }

    public void Attack(GameObject target)
    {
        anim.SetBool(Tags.ANIM_ISATTACKING, true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        
        PlayerHealth health = currentTarget.GetComponent<PlayerHealth>();

        health.DealDamage(damage);
    }

    private void AnimationStates()
    {
        if (!currentTarget)
        {
            anim.SetBool(Tags.ANIM_ISATTACKING, false);
        }
    }
}
