using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Attacker[] enemyPrefabs;

    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 5f;

    private bool isSpawning = true;

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private IEnumerator Start()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {

        int indexNumber = Random.Range(0, enemyPrefabs.Length);

        Spawn(enemyPrefabs[indexNumber]);

    }

    private void Spawn(Attacker attacker)
    {
        Attacker newEnemey = Instantiate(attacker, this.transform.position, Quaternion.identity) as Attacker;

        newEnemey.transform.parent = transform;
    }
}
