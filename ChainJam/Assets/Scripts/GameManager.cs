using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameData.energy = 100;
        GameData.fuel = 0;
        GameData.bombAmount = 3;
        GameData.plusBombAmount = 3;
        GameData.crossBombAmount = 3;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        if(GameData.energy <= 0 &GameData.fuel<= GameData.fuelToWin)
        {

        }
            Debug.Log("Game Over!");

    }
}
