using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneSwitch : MonoBehaviour
{
    public GameObject[] ToRemove, ToAdd;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }
    void clicked()
    {
        SceneSwitchHandler.Switch(ToRemove, ToAdd);
    }
}
