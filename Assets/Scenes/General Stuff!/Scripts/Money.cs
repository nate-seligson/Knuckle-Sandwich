using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
public class Money : MonoBehaviour
{
    public static float amount = 0;
    public static GameObject moneyUI;
    public GameObject moneyobj;
    public static float amt_to_change;
    void Awake()
    {
        moneyUI = moneyobj;
    }
    public static void changeMoney(float amt_changed)
    {
        GameObject money = Instantiate(moneyUI, GameObject.Find("Canvas").transform);
        money.GetComponent<CanvasRenderer>().cull = false;
        amt_to_change = amt_changed;
    }
}
