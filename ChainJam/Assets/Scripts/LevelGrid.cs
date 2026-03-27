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
    float tileScale = 1;
    Vector2 gridOffset = new Vector2(-3.5f, -4.5f); 

    //public Tilemap gridMap;
    public GameObject normalTile;
    public GameObject energyTile;
    public GameObject fuelTile;

    private GridTileType[,] grid; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CreateGrid()
    {
        //tileWidth = 1;
        //tileHeight = 1;


        grid = new GridTileType[gridWidth, gridHeight];

        for (int w = 0; w < gridWidth; w++)
        {
            for (int h = 0; h < gridHeight; h++)
            {
                grid[w, h] = GridTileType.Normal;
            }
        }

        grid[3, 3] = GridTileType.Fuel;
        grid[4, 4] = GridTileType.Energy;


        for (int w = 0; w < gridWidth; w++)
        {
            for (int h = 0; h < gridHeight; h++)
            {
                GameObject instaTile;
                switch (grid[w, h])
                {
                    case GridTileType.Normal:
                        instaTile = normalTile;
                        break;
                    case GridTileType.Energy:
                        instaTile = energyTile;
                        break;
                    case GridTileType.Fuel:
                        instaTile = fuelTile;
                        break;
                    default:
                        instaTile = normalTile;
                        break;
                }

                Instantiate(instaTile, new Vector2(w * tileScale, h * tileScale) + gridOffset, Quaternion.identity);
                //instaTile.transform.localScale = new Vector3(
                //    10 / gridWidth,
                //    10 / gridHeight,
                //    instaTile.transform.localScale.z);
            }
        }
    }
}
