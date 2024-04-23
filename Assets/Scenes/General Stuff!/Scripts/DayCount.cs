using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayCount : MonoBehaviour
{
    float DayLength = 150f;
    public static int day = 0;
    public static int timeElapsed = 0;
    public AudioSource bell;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine("Day");
    }
    void Update()
    {

        if (SceneManager.GetSceneByName("House").isLoaded)
        {
            Destroy(gameObject);
        }
    }
    void EndDay()
    {
        SceneManager.LoadScene("House");
        EnemySpawn.guys = 0;
        Destroy(gameObject);
        
    }
    IEnumerator Day()
    {
        for (var i = 0; i < DayLength; i++)
        {
            yield return new WaitForSeconds(1f);
            timeElapsed++;
        }
        bell.Play();
        yield return new WaitForSeconds(1);
        EndDay();
    }
}
