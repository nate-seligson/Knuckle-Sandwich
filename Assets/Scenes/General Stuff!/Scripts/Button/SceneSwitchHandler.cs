using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneSwitchHandler : MonoBehaviour
{
    public static void Switch(GameObject[] objs_to_remove, GameObject[] objs_to_add)
    {
        foreach (GameObject obj in objs_to_remove)
        {
            obj.GetComponent<CanvasRenderer>().cull = true;
            foreach (CanvasRenderer cr in obj.GetComponentsInChildren<CanvasRenderer>())
            {
                cr.cull = true;
            }
        }
        foreach (GameObject obj in objs_to_add)
        {
            obj.GetComponent<CanvasRenderer>().cull = false;
            foreach(CanvasRenderer cr in obj.GetComponentsInChildren<CanvasRenderer>())
            {
                cr.cull = false;
            }
            try
            {
                foreach (Image im in obj.GetComponentsInChildren<Image>())
                {
                    im.enabled = false;
                    im.enabled = true;
                }
            }
            catch { }
        }
    }
}
