using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridTesting : MonoBehaviour
{
    System.Random rng = new System.Random();

    private void Start()
    {
        GridSystem gridSystem1 = new GridSystem(20, 10);
    }
}