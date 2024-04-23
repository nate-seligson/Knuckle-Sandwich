using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ingredient : MonoBehaviour
{
    public string itemname;

    public bool stackable = true;

    public bool sliceable, toastable;

    public bool pickupable = true;

    public Sprite pickedup, laiddown;

    bool moving = false;

    public float toasted = 0;

    Vector3 move;
    void FixedUpdate()
    {
        if (moving)
        {
            GetComponent<Rigidbody>().AddForce(move * Vector3.Distance(Mousedrag.GetMouseWorldPos(), transform.position), ForceMode.Impulse);
        }
    }
    private void OnMouseDown()
    {
        Mousedrag.mouseisdown(gameObject);
        GetComponent<SpriteRenderer>().sprite = pickedup;
    }
    private void OnMouseDrag()
    {
        moving = true;
        move = Mousedrag.Mouseisdrag(gameObject);
    }
    void OnMouseUp()
    {
        moving = false;
    }

}
