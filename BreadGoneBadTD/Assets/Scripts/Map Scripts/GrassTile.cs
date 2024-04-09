using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offSetColor;
    [SerializeField] private TowerPlacer towerPlacer;

    private bool hasTower;

    void Start()
    {
        hasTower = false;
    }

    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        spriteRenderer.color = isOffset ? offSetColor : baseColor;
    }

    private void OnMouseDown()
    {
        if (!hasTower && towerPlacer.GetPlacementMode())
        {
            Debug.Log(this.name);
            towerPlacer.PlaceTower(this.transform);
            hasTower = true;
            highlight.SetActive(false);
        }
        Debug.Log(this.name);
    }

    private void OnMouseEnter()
    {
        if (!hasTower && towerPlacer.GetPlacementMode())
        {
            highlight.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (!hasTower && towerPlacer.GetPlacementMode())
        {
            highlight.SetActive(false);
        }
    }
}