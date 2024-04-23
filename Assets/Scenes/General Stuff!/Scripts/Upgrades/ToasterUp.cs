using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ToasterUp : MonoBehaviour
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
            BeToasted.popable = true;
        }
    }
}
