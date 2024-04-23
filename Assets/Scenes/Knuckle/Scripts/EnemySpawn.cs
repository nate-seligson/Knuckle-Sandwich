using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public static int guys = 0;
    // Update is called once per frame
    void Start()
    {
        for(var i=0; i<GuySpawner.taken.Length-1; i++)
        {
            if (GuySpawner.taken[i])
            {
                Instantiate(enemy, transform.position, transform.rotation);
                guys ++;
            }
        }
        StartCoroutine("SpawnEnemyLoop");
    }
    IEnumerator SpawnEnemyLoop()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        Instantiate(enemy, transform.position, transform.rotation);
        guys++;
        StartCoroutine("SpawnEnemyLoop");
    }
}
