using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{
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
        if (hasTower == false)
        {
            Instantiate(tower, this.transform, false);
            Debug.Log($"Tile {name} was clicked");
        }

        hasTower = true;
    }
}