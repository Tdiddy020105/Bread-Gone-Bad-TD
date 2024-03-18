using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField]
    private Color baseColor;
    [SerializeField]
    private Color offSetColor;

    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        spriteRenderer.color = isOffset ? offSetColor : baseColor;
    }
}