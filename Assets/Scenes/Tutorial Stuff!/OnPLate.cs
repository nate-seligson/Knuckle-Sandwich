using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPLate : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        if(col.transform.gameObject.GetComponent<Ingredient>().toasted > 1)
        {
            Popup.MakePopup("Put ham, cheese, and the other bread on the plate, and a toothpick last to finish.");
        }
    }
}
