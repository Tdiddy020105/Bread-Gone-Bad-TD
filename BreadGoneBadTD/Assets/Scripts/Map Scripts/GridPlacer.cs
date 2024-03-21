using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridPlacer : MonoBehaviour
{

    [SerializeField]
    private int gridWidth;
    [SerializeField]
    private int gridHeight;

    private void Start()
    {
        GridLogic gridSystem1 = new GridLogic(gridWidth, gridHeight, 10f);
    }
}