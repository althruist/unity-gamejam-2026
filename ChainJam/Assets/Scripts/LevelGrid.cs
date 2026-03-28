using UnityEngine;
using UnityEngine.Tilemaps;

enum GridTileType
{
    Normal, Energy, Fuel,
    Bomb, CrossBomb, PlusBomb,
    BombCrate, CrossBombCrate, PlusBombCrate,
    NatBomb, NatCrossBomb, NatPlusBomb
}


public class LevelGrid : MonoBehaviour
{
    public int gridLenght = 0;
    float tileScale = 1;
    Vector2 gridOffset = new Vector2(-4f, -5f);
    Vector2 tileOffset = new Vector2(0.5f, 0.5f);

    //public Tilemap gridMap;
    public GameObject normalTile;
    public GameObject energyTile;
    public GameObject fuelTile;
    public GameObject bombTile;
    public GameObject crossBombTile;
    public GameObject plusBombTile;
    public GameObject bombCrateTile;
    public GameObject crossBombCrateTile;
    public GameObject plusBombCrateTile;
    public GameObject natBombTile;
    public GameObject natCrossBombTile;
    public GameObject natPlusBombTile;

    private GridTileType[,] grid; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateGrid();
    }


    void CreateGrid()
    {
        Camera.main.orthographicSize = 5 * ((float) gridLenght / 10.0f);


        grid = new GridTileType[gridLenght, gridLenght];

        for (int w = 0; w < gridLenght; w++)
        {
            for (int h = 0; h < gridLenght; h++)
            {
                grid[w, h] = GridTileType.Normal;
            }
        }

        ////grid[3, 3] = GridTileType.Fuel;
        //grid[7, 16] = GridTileType.Bomb;
        //grid[5, 5] = GridTileType.CrossBomb;
        //grid[5, 16] = GridTileType.PlusBomb;
        RandomizeGrid();


        for (int w = 0; w < gridLenght; w++)
        {
            for (int h = 0; h < gridLenght; h++)
            {
                Instantiate(GetTileType(grid[w, h]), 
                    new Vector2(w * tileScale, h * tileScale) + (gridOffset * ((float) gridLenght / 10.0f)) + tileOffset,
                    Quaternion.identity, this.transform);
            }
        }
    }


    void RandomizeGrid()
    {
        float multiplyer = (float)(gridLenght) / 10;

        int EnergyNum = (int) Mathf.Round(Random.Range(5, 10) * multiplyer);
        InsertTiles(EnergyNum, GridTileType.Energy);
        int FuelNum = (int)Mathf.Round(Random.Range(5, 10) * multiplyer);
        InsertTiles(FuelNum, GridTileType.Fuel);

        int BombCrateNum = (int)Mathf.Round(multiplyer);
        InsertTiles(BombCrateNum, GridTileType.BombCrate);
        int CrossBombCrateNum = (int)Mathf.Round(Random.Range(2, 3) * multiplyer);
        InsertTiles(CrossBombCrateNum, GridTileType.CrossBombCrate);
        int PlusBombCrateNum = (int)Mathf.Round(Random.Range(2, 3) * multiplyer);
        InsertTiles(PlusBombCrateNum, GridTileType.PlusBombCrate);

        int NatBombNum = (int)Mathf.Round(Random.Range(1, 5) * multiplyer);
        InsertTiles(NatBombNum, GridTileType.NatBomb);
        int NatCrossBombNum = (int)Mathf.Round(Random.Range(1, 5) * multiplyer);
        InsertTiles(NatCrossBombNum, GridTileType.NatCrossBomb);
        int NatPlusBombNum = (int)Mathf.Round(Random.Range(1, 5) * multiplyer);
        InsertTiles(NatPlusBombNum, GridTileType.NatPlusBomb);
    }


    void InsertTiles(int tileCount, GridTileType tileType)
    {
        while (tileCount > 0)
        {
            int randX = Random.Range(0, gridLenght);
            int randY = Random.Range(0, gridLenght);
            if (grid[randX, randY] == GridTileType.Normal)
            {
                grid[randX, randY] = tileType;
                tileCount--;
            }
        }
    }

    GameObject GetTileType(GridTileType gridType)
    {
        switch (gridType)
        {
            case GridTileType.Normal:
                return normalTile;
            case GridTileType.Energy:
                return energyTile;
            case GridTileType.Fuel:
                return fuelTile;
            case GridTileType.Bomb:
                return bombTile;
            case GridTileType.CrossBomb:
                return crossBombTile;
            case GridTileType.PlusBomb:
                return plusBombTile;
            case GridTileType.BombCrate:
                return bombCrateTile;
            case GridTileType.CrossBombCrate:
                return crossBombCrateTile;
            case GridTileType.PlusBombCrate:
                return plusBombCrateTile;
            case GridTileType.NatBomb:
                return natBombTile;
            case GridTileType.NatCrossBomb:
                return natCrossBombTile;
            case GridTileType.NatPlusBomb:
                return natPlusBombTile;
            default:
                return normalTile;
        }
    }
}
