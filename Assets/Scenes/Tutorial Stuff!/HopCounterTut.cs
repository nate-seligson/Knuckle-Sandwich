using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HopCounterTut : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Stacking.stackheight = new List<GameObject>();
            SceneManager.LoadScene("Knuckletut");
        }
    }
}
