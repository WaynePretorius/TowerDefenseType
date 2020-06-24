using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject bulletpoint;

    private Animator animStates;
    private Spawner myLaneSpawner;
    private GameObject projectileParent;

    private void Start()
    {
        StartFunctions();
        SetLaneSpawner();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(Tags.GAMEOBJ_BULLETS);
        if (!projectileParent)
        {
            projectileParent = new GameObject(Tags.GAMEOBJ_BULLETS);
        }
    }

    private void StartFunctions()
    {
        animStates = GetComponent<Animator>();
    }

    private void Update()
    {
        ChangeAnimStates();
    }

    private void ChangeAnimStates()
    {
        if (IsAttackerInLane())
        {
            animStates.SetBool(Tags.ANIM_ISATTACKING,true);
        }
        else
        {
            animStates.SetBool(Tags.ANIM_ISATTACKING, false);
        }
    }

    private void SetLaneSpawner()
    {
        Spawner[] attackSpawners = FindObjectsOfType<Spawner>();

        foreach(Spawner attackSpawner in attackSpawners)
        {
            var spawnerPos = attackSpawner.transform.position.y;
            var myPos = transform.position.y;

            bool isCloseEnough = (Mathf.Abs(spawnerPos - myPos) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = attackSpawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (!myLaneSpawner) { return false; }
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Fire()
    {
        GameObject bullet = Instantiate(projectile, bulletpoint.transform.position, bulletpoint.transform.rotation) as GameObject;
        bullet.transform.parent = projectileParent.transform;
    }
}
