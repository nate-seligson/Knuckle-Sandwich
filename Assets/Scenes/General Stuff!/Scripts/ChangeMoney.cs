using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeMoney : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("change");
    }

    IEnumerator change()
    {
        yield return new WaitForSeconds(1);
        Money.amount += Money.amt_to_change;
        if (Money.amount < 0)
        {
            Money.amount = 0;
        }
        GetComponent<TextMeshProUGUI>().text = Money.amount.ToString();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
