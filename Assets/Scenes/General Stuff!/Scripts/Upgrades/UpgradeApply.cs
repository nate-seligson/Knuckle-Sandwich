using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeApply : MonoBehaviour
{
    public Upgrade upgrade;
    public TextMeshProUGUI name, price, buttonText;
    public Image img;
    public Button button;
    bool bought = false;
    void Start()
    {
        img.sprite = upgrade.img;
        name.text = upgrade.name;
        price.text = upgrade.price.ToString();
        button.onClick.AddListener(clicked);
        if (bought)
        {
            Bought();
        }
        else if(Money.amount < upgrade.price)
        {
            buttonText.text = "Insufficient Funds";
        }
    }
    void Bought()
    {
        buttonText.text = "BOUGHT";
        Money.changeMoney(-1 * upgrade.price);
    }
    void clicked()
    {
        if(Money.amount < upgrade.price)
        {
            return;
        }
        bought = true;
        Bought();
    }
}
