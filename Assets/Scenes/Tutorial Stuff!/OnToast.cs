using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnToast : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        Popup.MakePopup("Wait 10 seconds for it to toast");
        StartCoroutine("wait");
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(10);
        Popup.MakePopup("Take the toast out of the toaster.");
        StopCoroutine("wait");
    }
    void OnMouseDown()
    {
        Popup.MakePopup("Put a piece of bread on the plate");
    }
}
