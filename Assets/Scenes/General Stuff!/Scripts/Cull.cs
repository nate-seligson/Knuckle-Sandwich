using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cull : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (CanvasRenderer cr in gameObject.GetComponentsInChildren<CanvasRenderer>())
        {
            cr.cull = true;
        }
    }
}
