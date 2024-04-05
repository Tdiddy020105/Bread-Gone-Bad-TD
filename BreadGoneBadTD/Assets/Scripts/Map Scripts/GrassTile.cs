using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offSetColor;
    [SerializeField] private GameObject tower;

    private bool hasTower = false;

    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        spriteRenderer.color = isOffset ? offSetColor : baseColor;
    }

    private void OnMouseDown()
    {
        PlaceTower();
    }

    private void PlaceTower()
    {
        if (hasTower == false)
        {
            Debug.Log("Tiles has no tower true");
            if (GetComponent<Tower>().GetData().price <= CurrencyManager.Instance.GetCurrencyAmount()) //Object reference not set to instance of an object...
            {
                Debug.Log("You can affordd this tower check");
                Instantiate(tower, this.transform, false);
                CurrencyManager.Instance.Spend(GetComponent<Tower>().GetData().price); //Object reference not set to instance of an object...
                hasTower = true;
            }
        }
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}