using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject wall;
    public GameObject background;

    public GameObject levelCards;

    public Image card1Top;
    public TextMeshProUGUI card1LevelIncrease;
    public Image card1Bot;

    public Image card2Top;
    public TextMeshProUGUI card2LevelIncrease;
    public Image card2Bot;

    public Image card3Top;
    public TextMeshProUGUI card3LevelIncrease;
    public Image card3Bot;

    public Sprite nextLevelNormal;
    public Sprite nextLevelEneFuel;
    public Sprite nextLevelBombs;
    public Sprite nextLevelCrates;
    public Sprite upgradeBomb;
    public Sprite upgradeCrossBomb;
    public Sprite upgradePlusBomb;


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
        if (GameData.fuel >= GameData.fuelToWin && !levelCards.activeSelf)
        {
            CreateLevelCards();
        }
    }


    void CreateLevelCards()
    {
        levelCards.SetActive(true);

        card1Top.sprite = GetNextLevelSprite(Random.Range(0,4));
        //Debug.Log(card1Top == nextLevelNormal);
        card2Top.sprite = GetNextLevelSprite(Random.Range(0, 4));
        card3Top.sprite = GetNextLevelSprite(Random.Range(0, 4));

        card1LevelIncrease.text = Random.Range(0, 3).ToString();
        card2LevelIncrease.text = Random.Range(0, 3).ToString();
        card3LevelIncrease.text = Random.Range(0, 3).ToString();

        card1Bot.sprite = GetBombUpgradeSprite(Random.Range(0, 3));
        card2Bot.sprite = GetBombUpgradeSprite(Random.Range(0, 3));
        card3Bot.sprite = GetBombUpgradeSprite(Random.Range(0, 3));
    }


    Sprite GetNextLevelSprite(int num)
    {
        switch (num)
        {
            case 0:
                return nextLevelNormal;
            case 1:
                return nextLevelEneFuel;
            case 2:
                return nextLevelBombs;
            case 3:
                return nextLevelCrates;
            default:
                return nextLevelNormal;
        }
    }

    Sprite GetBombUpgradeSprite(int num)
    {
        switch (num)
        {
            case 0:
                return upgradeBomb;
            case 1:
                return upgradeCrossBomb;
            case 2:
                return upgradePlusBomb;
            default:
                return upgradeBomb;
        }
    }


    public void ButtonTest()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }
}
