using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuyTut : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public GameObject bg;
    public int index;
    int waitTime = 120;
    public List<string> order = new List<string>();
    bool died = false;
    public List<string> Quips = new List<string>()
    {
    };
    void Start()
    {
        waitTime = Stars.WaitTime(waitTime);
        bg.SetActive(false);
    }
    public List<string> GetOrder()
    {
        return order;
    }
    IEnumerator BeMean()
    {
        yield return new WaitForSeconds(Random.Range(10, 30));
        DisplayText(Quips[Random.Range(0, Quips.Count)]);
        StartCoroutine("BeMean");
    }
    void OnMouseDown()
    {
        string text;
        Popup.MakePopup("Grab the BREAD from the left box.");
        if (order.Count == 0)
        {
            order = new List<string>() {"ham, cheese"};
        }
        text = "Can I get a sandwich with ";
        for(var i = 0; i<order.Count-1; i++)
        {
            text += order[i] + ", ";
        }
        text += "and " + order[order.Count-1] + "?";
        DisplayText(text, 5);
    }
    public void DisplayText(string text, int seconds = 2)
    {
        bg.SetActive(true);
        txt.text = text;
        StartCoroutine("goaway", seconds);
    }
    public void die(int ingredients, int wrong)
    {
        float num = ((float)wrong / (float)ingredients);
        Debug.Log(num);
        died = true;
    }
    IEnumerator goaway(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        txt.text = "";
        bg.SetActive(false);
        if (died)
        {
            GuySpawner.taken[index] = false;
            Destroy(gameObject);
        }
    }
}
