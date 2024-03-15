using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] private int amount;
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        textMeshPro.text = amount.ToString();
    }

    public void Spend(int cost)
    {
        if (CheckAmount(cost))
        {
            amount -= cost;
            textMeshPro.text = amount.ToString();
        }
        else
        {
            // enable & disable the display of error message that you don't have enough currency
        }
    }

    public void Obtain(int income)
    {
        amount += income;
        textMeshPro.text = amount.ToString();
    }

    private Boolean CheckAmount(int cost)
    {
        return amount >= cost;
    }
}
