using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonHandler : MonoBehaviour
{
    Animator an;
    Image im;
    public LocalButton data;
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
        im = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (an.GetBool("Normal"))
        {
            im.sprite = data.sprite;
        }
        else if (an.GetBool("Highlighted"))
        {
            im.sprite = data.hovered;
        }
    }
}
