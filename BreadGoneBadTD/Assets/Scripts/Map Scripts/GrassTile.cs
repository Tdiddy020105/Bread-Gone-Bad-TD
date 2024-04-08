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
    [SerializeField] private TowerPlacer towerPlacer;

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
        if (!hasTower)
        {
            towerPlacer.PlaceTower(this.transform);
            hasTower = true;
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