using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class SleepButton : MonoBehaviour
{
    public GameObject[] BG;
    public TextMeshProUGUI txt;
    public GameObject timeHandler;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
        foreach (CanvasRenderer cr in gameObject.GetComponentsInChildren<CanvasRenderer>())
        {
            cr.cull = false;
        }
    }
    public void clicked()
    {
        DayCount.day += 1;
        foreach (GameObject g in BG)
        {
            try
            {
                g.GetComponent<Renderer>().enabled = false;
            }
            catch
            {
                g.GetComponent<CanvasRenderer>().cull = true;
            }
        }
        txt.gameObject.SetActive(true);
        txt.text = "Day " + DayCount.day.ToString();
        StartCoroutine("switchscene");
    }
    IEnumerator switchscene()
    {
        Money.changeMoney(0);
        yield return new WaitForSeconds(2f);
        Instantiate(timeHandler);
        SceneManager.LoadScene("Sandwich");
    }
}
