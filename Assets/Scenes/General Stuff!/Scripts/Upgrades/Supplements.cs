using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Supplements : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    // Update is called once per frame
    void clicked()
    {
        if (GetComponentInChildren<TextMeshProUGUI>().text != "BOUGHT")
        {
            PunchControls.damage += 10;
        }
    }
}
