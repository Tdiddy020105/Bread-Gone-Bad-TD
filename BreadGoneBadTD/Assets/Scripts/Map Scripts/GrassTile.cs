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
            // Get the position of the player character
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 playerPosition = player.transform.position;

            // Calculate the distance between this tile and the player character
            float distanceToPlayer = Vector3.Distance(playerPosition, transform.position);

            // Define your desired range for tower placement (you can adjust this value)
            float placementRange = 10f; // Adjust this value as needed

            // Check if the tile is within range of the player character
            if (distanceToPlayer <= placementRange)
            {
                // Place tower only if within range
                towerPlacer.PlaceTower(this.transform);
                hasTower = true;
                highlight.SetActive(false);
            }
            else
            {
                Debug.Log("Tile is out of range for tower placement.");
            }
        }
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