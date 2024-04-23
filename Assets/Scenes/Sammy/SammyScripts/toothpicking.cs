using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toothpicking : MonoBehaviour
{
    bool canorderup = false;
    List<GameObject> sammyingredients = new List<GameObject>();
    List<string> sammynames = new List<string>();
    GameObject guyTouching;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "StackPlate")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            try
            {
                transform.position = Stacking.stackheight[Stacking.stackheight.Count - 1].transform.position;
            }
            catch { }
            foreach (Transform child in collision.gameObject.transform)
            {
                if(child.gameObject.GetComponent<Ingredient>() == null) {
                    continue;
                }
                child.transform.parent = transform;
                Ingredient ing = child.gameObject.GetComponent<Ingredient>();
                if (!ing.toastable)
                {
                    sammynames.Add(ing.itemname);
                }
                else
                {
                    sammynames.Add(Ordering.IsToasted(ing));
                }
            }
            Stacking.stackheight.Clear();
            GetComponent <Rigidbody>().AddForce(Vector3.up * 200);
            canorderup = true;
        }

    }
    void FixedUpdate()
    {
        RaycastHit hit;
        if (canorderup)
        {
            if(Physics.Raycast(transform.position, Vector3.forward, out hit, 100, LayerMask.GetMask(LayerMask.LayerToName(3))))
            {
                guyTouching = hit.collider.gameObject;
            }
            else if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.collider.gameObject.tag == "Guy")
            {
                guyTouching = hit.collider.transform.parent.gameObject;
            }
            else
            {
                guyTouching = null;
            }
        }
    }
    void OnMouseUp()
    {
        if (guyTouching != null)
        {
            int diff = Ordering.Orderup(guyTouching.GetComponent<Guy>().GetOrder(), sammynames);
            Reset(diff);
        }
    }
    void Reset(int diff)
    {
        Destroy(gameObject);
        Guy guy = guyTouching.GetComponent<Guy>();
        guy.die(sammynames.Count, diff);
        sammyingredients = new List<GameObject>();
        sammynames = new List<string>();
        canorderup = false;
    }

}
