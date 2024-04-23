using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarC : MonoBehaviour
{
    public RectTransform mover;
    void Start()
    {
        DontDestroyOnLoad(this.transform.parent.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        float pos = (-118f + Stars.stars / 5f * 71f);
        mover.anchoredPosition = new Vector2(pos, mover.anchoredPosition.y);
    }
}
