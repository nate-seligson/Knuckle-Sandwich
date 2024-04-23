using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousedrag : MonoBehaviour
{
    public static Vector3 mOffset;
    public static float mZCoord;
    public static void mouseisdown(GameObject theobject)
    {
        mZCoord = Camera.main.WorldToScreenPoint(theobject.transform.position).z;
        //need to store offset = gameobject world pos - mouse world pos
        mOffset = theobject.transform.position - GetMouseWorldPos();


    }

    public static Vector3 GetMouseWorldPos()
    {
        //pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;

        //z coordinate of game object
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public static Vector3 Mouseisdrag(GameObject theobject)
    {
        Vector3 MousePos = GetMouseWorldPos();
        return ((MousePos + mOffset) - (theobject.transform.position + new Vector3(0,-3,0))).normalized;


        //transform.position = mousePosWorld = mOffset;
    }
  
}
