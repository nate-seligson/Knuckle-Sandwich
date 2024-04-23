using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabread : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown()
    {
        Popup.MakePopup("Move 2 pieces of bread to the toaster on the right.");
    }
}
