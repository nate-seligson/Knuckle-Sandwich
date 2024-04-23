using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuySpawner : MonoBehaviour
{
    public GameObject guy;
    public Transform[] spotTransforms;
    Vector3[] spots = new Vector3[4];
    public static bool[] taken = new bool[4];
    void Start()
    {
        StartCoroutine("spawn");
        for(var i = 0; i<taken.Length; i++)
        {
            taken[i] = false;
        }
        for (var i = 0; i < spotTransforms.Length; i++)
        {
            spots[i] = spotTransforms[i].position;
        }
        for (var i = 0; i<EnemySpawn.guys; i++)
        {
            SpawnGuy();
        }
        EnemySpawn.guys = 0;
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(Random.Range(5,20));
        SpawnGuy();
        StartCoroutine("spawn");
    }
    void SpawnGuy()
    {
        Vector3 pos = Vector3.zero;
        int indexx = 0;
        for (var i = 0; i < taken.Length; i++)
        {
            if (!taken[i])
            {
                taken[i] = true;
                pos = spots[i];
                indexx = i;
                break;
            }
        }
        if(pos == Vector3.zero)
        {
            return;
        }
        GameObject guyy = Instantiate(guy, pos, guy.transform.rotation);
        guyy.GetComponent<Guy>().index = indexx;
    }
}
