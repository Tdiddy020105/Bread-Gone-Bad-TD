using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    //[SerializeField] private int amount;
    private TextMeshProUGUI textMeshPro;
    private Color color;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        //textMeshPro.text = amount.ToString();
        textMeshPro.text = CurrencyManager.Instance.GetCurrencyAmount().ToString();
    }

    private void Update()
    {
        textMeshPro.text = CurrencyManager.Instance.GetCurrencyAmount().ToString();
    }

    //public void Spend(int cost)
    //{
    //    if (CheckAmount(cost))
    //    {
    //        amount -= cost;
    //        textMeshPro.text = amount.ToString();
    //    }
    //    else
    //    {
    //        // enable & disable the display of error message that you don't have enough currency
    //    }
    //}

    //public void Obtain(int income)
    //{
    //    amount += income;
    //    textMeshPro.text = amount.ToString();
    //}

    //private Boolean CheckAmount(int cost)
    //{
    //    return amount >= cost;
    //}
}
