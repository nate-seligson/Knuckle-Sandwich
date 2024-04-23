using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Returner : MonoBehaviour
{
    bool touching = false;
    public GameObject returnObj;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && touching)
        {
            SceneManager.LoadScene("Sandwich");
        }
    }
    void OnCollisionStay(Collision col)
    {
        if(col.transform.gameObject.tag == "Player")
        {
            returnObj.transform.position = col.contacts[0].point;
        }
        touching = true;
    }
    void OnCollisionExit(Collision col)
    {
        returnObj.transform.position = new Vector3(100, 100, 100);
        touching = false;
    }
}
