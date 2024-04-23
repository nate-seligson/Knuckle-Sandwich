using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Endd");
    }
    IEnumerator Endd()
    {
        yield return new WaitForSeconds(7f);
        Popup.MakePopup("When you beat someone up, your STAR RATING goes down.");
        yield return new WaitForSeconds(4f);
        Popup.MakePopup("The lower the star rating, the less money customers have. But, the harder they are to kill.");
        yield return new WaitForSeconds(6f);
        Popup.MakePopup("The higher the star rating, the more money customers have, But, they are easier to kill.");
        yield return new WaitForSeconds(6f);
        Popup.MakePopup("Customers with more money are more demanding.");
        yield return new WaitForSeconds(4f);
        Popup.MakePopup("Thats all for now! Time to go home.");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("House");

    }

}
