using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLogic : MonoBehaviour
{
    private int gridWidth;
    private int gridHeight;
    private float cellSize;
    private int[,] gridArray;

    public GridLogic(int gridWidth, int gridHeight, float cellSize)
    {
        this.gridWidth = gridWidth;
        this.gridHeight = gridHeight;
        this.cellSize = cellSize;

        gridArray = new int[gridWidth, gridHeight];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GridVisualiser.CreateWorldText(null, gridArray[x, y].ToString(), GetWorldPosition(x, y), 20, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center, 5000);
            }
        }
    }
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
}