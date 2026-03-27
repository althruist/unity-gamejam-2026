using UnityEngine;
using UnityEngine.Tilemaps;

enum GridTileType
{
    Normal,
    Energy,
    Fuel
}


public class LevelGrid : MonoBehaviour
{
    public int gridWidth = 0;
    public int gridHeight = 0;
    public Tilemap gridMap;
    public TileBase normalTile;

    //private GridTileType[,] grid; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //grid = new GridTileType[gridWidth,gridHeight];

        for (int w = 0; w < gridWidth; w++)
        {
            for (int h = 0; h < gridHeight; h++)
            {
                gridMap.SetTile(new Vector3Int(w, h), normalTile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
