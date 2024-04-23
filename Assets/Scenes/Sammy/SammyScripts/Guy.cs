using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Guy : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public GameObject bg;
    public int index;
    int waitTime = 120;
    public List<string> order = new List<string>();
    bool died = false;
    public List<string> Quips = new List<string>()
    {
        "Hey, pal, whats taking so long?",
        "Buddy... I wont wait all day",
        "lol",
        "nice place you got here",
        "I hate you",
        "Go fuck yaself!"
    };
    void Start()
    {
        waitTime = Stars.WaitTime(waitTime);
        bg.SetActive(false);
        StartCoroutine("BeMean");
        StartCoroutine("HavePatience");
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
    IEnumerator HavePatience()
    {
        yield return new WaitForSeconds(waitTime);
        died = true;
        DisplayText("Taking too long! Im outta here...");
    }
    void OnMouseDown()
    {
        string text;
        if (order.Count == 0)
        {
            order = Ordering.generateorder();
        }
        text = "Can I get a sandwich with ";
        for(var i = 0; i<order.Count-1; i++)
        {
            text += order[i] + ", ";
        }
        text += "and " + order[order.Count-1] + "?";
        DisplayText(text, 5);
    }
    void DisplayText(string text, int seconds = 2)
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
        if (num >= 0.8)
        {
            DisplayText("this shit fucking sucks lmaoooooo");
        }
        else if (num >= 0.6)
        {
            DisplayText("I've had better.");
        }
        else if (num >= 0.3)
        {
            DisplayText("yum!");
        }
        else
        {
            DisplayText("DELICIOUS! Thank you!");
        }
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
