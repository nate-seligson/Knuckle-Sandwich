using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientStorage : MonoBehaviour
{
    public GameObject ingredient;
    GameObject obj;
  
    void OnMouseDown()
    {
        obj = Instantiate(ingredient, new Vector3(transform.position.x, transform.position.y + 4, 7), transform.rotation);
        Mousedrag.mouseisdown(obj);
    }
}
