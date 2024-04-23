using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Popup : MonoBehaviour
{
    public static GameObject popUp;
    public GameObject popupSilly;
    // Update is called once per frame
    void Start()
    {
        popUp = popupSilly;
    }
    public static void MakePopup(string text)
    {
        popUp.GetComponent<TextMeshProUGUI>().text = text;
    }
}
