using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoBack : MonoBehaviour
{
    public Animator an;
    // Update is called once per frame
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }
    void clicked()
    {
        an.SetBool("Shop", false);
    }
}
