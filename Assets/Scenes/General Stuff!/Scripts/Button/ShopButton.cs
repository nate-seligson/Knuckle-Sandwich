using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopButton : MonoBehaviour
{
    public Animator an;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
        foreach(GameObject obj in GetComponent<SceneSwitch>().ToAdd)
        {
            foreach (CanvasRenderer cr in obj.GetComponentsInChildren<CanvasRenderer>())
            {
                cr.cull = true;
            }
        }
        foreach (CanvasRenderer cr in gameObject.GetComponentsInChildren<CanvasRenderer>())
        {
            cr.cull = false;
        }
    }

    // Update is called once per frame
    void clicked()
    {
        an.SetBool("Shop", true);
    }
}
