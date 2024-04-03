using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    [SerializeField] private int amount;
    private TextMeshProUGUI textMeshPro;
    private Color color;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro.text = amount.ToString();
        color = textMeshPro.color;
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
            StartCoroutine(FlashRed());
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

    private IEnumerator FlashRed()
    {
        GetComponent<Image>().color = Color.red;
        textMeshPro.color = Color.red;
        yield return new WaitForSeconds(1);
        GetComponent<Image>().color = Color.white;
        textMeshPro.color = color;
    }
}
