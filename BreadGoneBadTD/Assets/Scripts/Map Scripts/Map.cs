using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Sets the width of the generated grid.")]
    [Range(1, 100)]
    private int width;

    [SerializeField]
    [Tooltip("Sets the height of the generated grid.")]
    [Range(1, 100)]
    private int height;
    public int towersPlaced;

    [SerializeField] private Tile placeholderTile;
    [SerializeField] private Tile grassTile;
    [SerializeField] private Tile gravelTile;

    private Dictionary<Vector2, Tile> tiles;

    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var randomTile = Random.Range(0, 6) == 3 ? gravelTile : grassTile;
                var spawnedTile = Instantiate(grassTile, new Vector3(x*4, y*4), Quaternion.identity, this.transform);
                spawnedTile.name = $"Tile {x+1} {y+1}";

                spawnedTile.Init(x, y);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }

    public void DestroyGrid()
    {
        GameObject[] allTiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in allTiles)
        {
            DestroyImmediate(tile);
        }
    }

    public void Towercount(){
        towersPlaced++;
    }
}