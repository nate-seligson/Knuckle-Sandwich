using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
public class Ordering : MonoBehaviour
{
    public static List<string> itemstoorder = new List<string>() { "turkey", "cheese", "ham", "tomato", "lettuce",};


    // Start is called before the first frame update
    private void Start()
    {

        Physics.gravity = new Vector3(0, -100f);
        generateorder();
    }

    public static string IsToasted(Ingredient i)
    {
        if (i.toasted >= BeToasted.toastSeconds + 5)
        {
            return "toast00";
        }
        else if (i.toasted <= BeToasted.toastSeconds - 2)
        {
            return "toast0";
        }
        return "toast";
    }
    public static List<string> generateorder()
    {
        List<string> theirorder = new List<string>();

        int samnum = Stars.howmanyinsam();
        for (int i = 0; i < samnum; i++)
        {
            int j = Random.Range(0, itemstoorder.Count);
            theirorder.Add(itemstoorder[j]);
        }
        return theirorder;
    }

    public static int Orderup(List<string> theirorder, List<string> stackitemsnames)
    {
        theirorder.Insert(0, "toast");
        theirorder.Add("toast");
        theirorder.Sort();
        stackitemsnames.Sort();
        int difference = CompareSammy(theirorder, stackitemsnames);
        Stars.MoneyPaid(theirorder.Count, difference);
        Stars.MadeSandwich(difference);
        return difference;

    }
    public static int CompareSammy(List<string> theirorder, List<string> stackitemsnames)
    {
        int itemlen;
        if (theirorder.Count < stackitemsnames.Count)
        {
            itemlen = theirorder.Count;

        }
        else
        {
            itemlen = stackitemsnames.Count;
        }
        int wrongthings = Mathf.Abs(theirorder.Count - stackitemsnames.Count);

        for (int i = 0; i < itemlen; i++)
        {
            Debug.Log("order:" + theirorder[i]);
            Debug.Log("you had:" + stackitemsnames[i]);
            if (theirorder[i] != stackitemsnames[i])
            {
                wrongthings += 1;
            }
        }
        Debug.Log(wrongthings);
        return wrongthings;
    }
}
