using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private Color baseColor;
    //[SerializeField] private Color offSetColor;
    [SerializeField] private GameObject tower;

    private bool hasTower = false;

    /*
    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        spriteRenderer.color = isOffset ? offSetColor : baseColor;
    }
    */

    private void OnMouseDown()
    {
        PlaceTower();
    }

    private void PlaceTower()
    {
        if (hasTower == false)
        {
            Instantiate(tower, this.transform, false);
            CurrencyManager.Instance.Spend(10/*Pass TowerData.price here depending on which Tower is placed. This also needs UI support.*/);
        }

        hasTower = true;
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