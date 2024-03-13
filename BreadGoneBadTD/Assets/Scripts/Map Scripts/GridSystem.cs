using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private int gridWidth;
    private int gridHeight;
    private int[,] gridArray;

    public GridSystem(int gridWith, int gridHeight)
    {
        this.gridWidth = gridWith;
        this.gridHeight = gridHeight;

        gridArray = new int[gridWidth, gridHeight];

        Debug.Log("Width" + gridWidth + " " + "Height" + gridHeight);
    }
}