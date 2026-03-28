using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject wall;
    public GameObject background;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameData.energy = 100;
        GameData.fuel = 0;
        GameData.bombAmount = 3;
        GameData.plusBombAmount = 3;
        GameData.crossBombAmount = 3;

        wall.transform.position = new Vector3(GameData.gridLenght - 2, 0, 0);
        background.transform.position = new Vector3((float) (GameData.gridLenght - 10) /2, 0, 1);
        background.GetComponent<SpriteRenderer>().size =  new Vector2(GameData.gridLenght + 8, 10);
    }

    // Update is called once per frame
    void Update()
    {
        loadLoseScreen();
        loadWin();
    }

    //public void GameOver()
    //{
    //    if(GameData.energy <= 0 &GameData.fuel<= GameData.fuelToWin)
    //    {

    //    }
    //        Debug.Log("Game Over!");

    //}


    void loadLoseScreen()
    {
        if (GameData.energy <= 0)
        {
            //Time.timeScale = 1f;
            SceneManager.LoadScene("LoseScene");
        }
    }

    void loadWin()
    {
        if (GameData.fuel <= GameData.fuelToWin)
        {
            //Make next level Button
        }
    }
}
