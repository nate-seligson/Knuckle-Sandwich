using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public static float maxStars = 5;
    public static float stars = 2.5f;
    public static float base_money_from_killing_a_bitch = 5;
    public static void KilledPerson()
    {
        if (stars > 0)
        {
            stars -= 0.3f;
        }
        if(stars < 0)
        {
            stars = 0;
        }
        Money.changeMoney(base_money_from_killing_a_bitch * (stars * 2));
    }
    public static void MadeSandwich(int wrong)
    {
        if (stars < maxStars)
        {
            stars += 0.2f / (1 + (wrong * stars));
        }
    }
    public static float EnemyDamage(float baseDamage)
    {
        return baseDamage * (float)(maxStars - stars);
    }
    public static float EnemyHealth(float baseHealth)
    {
        return baseHealth * (float)(maxStars - stars);
    }
    public static int WaitTime(float baseWaitTime)
    {
        return (int)Mathf.Round(baseWaitTime / stars);
    }
    public static int howmanyinsam()
    {
        return (int) Mathf.Round(Random.Range(1, 2) + (stars));
    }
    public static float MoneyPaid(int len, int wrong)
    {
        float r = (len * stars) - (wrong * stars);
        Money.changeMoney(r);
        return r;
    }
}