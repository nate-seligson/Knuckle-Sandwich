using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeToasted : MonoBehaviour
{
    public GameObject Brd;
    Animator tstanimator;
    public bool toasting;
    float[] toastInToaster = new float[4];
    public static float toastSeconds = 10f;
    public static bool popable = false;
    //If touching toaster, rotate and stay in there
    private void Start()
    {
        tstanimator = GetComponent<Animator>();
        tstanimator.SetBool("toasting", false);
        Vector3 toasterp = gameObject.transform.position;
        for(var i = 0; i<toastInToaster.Length; i++)
        {
            toastInToaster[i] = -1;
        }



    }
    private void OnCollisionEnter(Collision collision) //when bread collides w something
    {
        if (collision.transform.gameObject.GetComponent<Ingredient>().toastable && ToasterHasSpace()) //if that thing is toaster
        {
            Destroy(collision.transform.gameObject);
            FillToaster(collision.transform.gameObject);
        }
    }
    bool ToasterHasSpace()
    {
        foreach(float f in toastInToaster)
        {
            if(f == -1)
            {
                return true;
            }
        }
        return false;
    }
    void FillToaster(GameObject obj)
    {
        toasting = true;
        tstanimator.SetBool("toasting", true);
        for (var i = 0; i<toastInToaster.Length; i++)
        {
            if (toastInToaster[i] == -1)
            {
                StartCoroutine("Toast", i);
                toastInToaster[i] = obj.GetComponent<Ingredient>().toasted;
                break;
            }
        }
    }
    IEnumerator Toast(int index)
    {
        while (toasting)
        {
            toastInToaster[index] += 1;
            yield return new WaitForSeconds(1);
            if (popable)
            {
                foreach(float i in toastInToaster)
                {
                    if(i == 10)
                    {
                        toasting = false;
                        PopToast();
                    }
                }
            }
        }
    }
    void OnMouseDown()
    {
        if (toasting)
        {
            PopToast();
        }
        toasting = false;
    }
    void PopToast()
    {
        tstanimator.SetBool("toasting", false);
        tstanimator.SetBool("burning", false);
        for (var i = 0; i<toastInToaster.Length; i++)
        {
            if (toastInToaster[i] != -1)
            {
                GameObject toast = Instantiate(Brd, transform.position + new Vector3(0, 5f, 0), transform.rotation);
                toast.tag = "toast";
                toast.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-2000,-1500), 2000, 0));
                toast.GetComponent<Ingredient>().toasted = toastInToaster[i];
                ApplyToastTex(toast);
                toastInToaster[i] = -1;
            }
        }
        tstanimator.SetBool("toasting", false);
    }
    void ApplyToastTex(GameObject obj)
    {
        float secondsPassed = obj.GetComponent<Ingredient>().toasted;
        Material mat = obj.GetComponent<Renderer>().material;
        Color color = new Color();
        if(secondsPassed <= toastSeconds)
        {
            color = new Color(1, (255 - (12.3f * secondsPassed))/255, (255 - (25.5f * secondsPassed))/255);
        }
        else if (secondsPassed <= 2 * toastSeconds)
        {
            tstanimator.SetBool("burning", true);
            color = new Color((255 - (25.5f * (secondsPassed - toastSeconds)))/255, (132 - (13.2f * (secondsPassed - toastSeconds)))/255, 0);
        }
        else
        {
            color = new Color(0, 0, 0);
        }
        mat.color = color;
    }

}
