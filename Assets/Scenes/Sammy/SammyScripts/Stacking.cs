using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    public static List<GameObject> stackheight = new List<GameObject>();
    bool DoRaycast = false;
    Coroutine Throwinair;
    GameObject stackeditem;
    float drag, mass;
    RigidbodyConstraints constraints;


    private void OnCollisionEnter(Collision c)
    {
        Ingredient ing;
        if (c.gameObject.GetComponent<Ingredient>() == null)
        {
            return;
        }
        ing = c.gameObject.GetComponent<Ingredient>();
        bool stackable = ing.stackable;
        //if it collies w the top of the hitbox, and is stackable
        if (stackable)
        {
            ing.stackable = false;
            //stackable = false;
            stackeditem = c.gameObject;
            SaveRigidbodyShit(stackeditem.GetComponent<Rigidbody>());
            Destroy(stackeditem.GetComponent<Rigidbody>());
            //bool thestacked = c.gameObject.GetComponent<Ingredient>().stackable;
            //get rid of rigidbody, can only have one per family
            stackeditem.transform.rotation = Quaternion.Euler(0, 0, 0);
            stackeditem.transform.position = new Vector3(transform.position.x, 20, transform.position.z);
            //move to the position with offset so its above
            DoRaycast = true;
            stackeditem.transform.parent = gameObject.transform;
            //parent it to get colliders together
            stackheight.Add(c.gameObject);


            ing.pickupable = false;
            c.gameObject.GetComponent<Collider>().gameObject.GetComponent<SpriteRenderer>().sprite = ing.laiddown;
            

        }
       
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        if (DoRaycast && Physics.Raycast(stackeditem.transform.position, Vector3.down, out hit, 100, LayerMask.GetMask(LayerMask.LayerToName(1))))
        {
            float offset = 0;
           /* if (hit.collider.gameObject == gameObject) {
                offset = GetComponent<Collider>().bounds.extents.y * stackeditem.transform.localScale.y; // you rapscallion! You scallywag of brobdingnagian proportion! He has forgotten to multiply by the scale! Oh ho! How this tickles me. Ho ho ho! Sorry, just having a laugh.
            }*/
            stackeditem.transform.position = new Vector3(transform.position.x, hit.point.y - ((hit.point.y-transform.position.y)/3), transform.position.z);
            stackeditem.layer = 1;
            DoRaycast = false;
        }
    }
    private void OnMouseDown()
    {
        if (stackheight.Count > 0)
        {
            GameObject topone = stackheight[stackheight.Count - 1];
            Vector3 toponepos = topone.transform.position;
            Rigidbody rigidbody = topone.AddComponent<Rigidbody>();
            AddRigidbodyShit(rigidbody);
            rigidbody.useGravity = true;
            topone.transform.parent = null;
            // toponepos = new Vector3(toponepos.x, toponepos.y + 100);
            Throwinair = StartCoroutine(throwinair());
            
            stackheight.Remove(topone);
            
        }

    }
    void SaveRigidbodyShit(Rigidbody rb)
    {
        drag = rb.drag;
        mass = rb.mass;
        constraints = rb.constraints;
    }
    void AddRigidbodyShit(Rigidbody rb)
    {
        rb.drag = drag;
        rb.constraints = constraints;
        rb.mass = mass;
    }
    IEnumerator throwinair()
    {
        GameObject topone = stackheight[stackheight.Count - 1];
        topone.GetComponent<Rigidbody>().AddForce(0, 4000, 0);
        topone.GetComponent<Ingredient>().pickupable = true;
        yield return new WaitForSeconds(0.3f);
        topone.GetComponent<Ingredient>().stackable = true;
        topone.layer = 0;
    }
}
