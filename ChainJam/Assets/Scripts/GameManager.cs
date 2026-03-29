using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    public GameObject wall;
    public GameObject background;

    public GameObject levelCards;
    public int currentChain;


    public Image card1Top;
    public TextMeshProUGUI card1LevelIncrease;
    public Image card1Bot;


    public TextMeshProUGUI card1BombLevelText;
    public TextMeshProUGUI card2BombLevelText;
    public TextMeshProUGUI card3BombLevelText;
    public TextMeshPro tileExplosionText;

    public Image card2Top;
    public TextMeshProUGUI card2LevelIncrease;
    public Image card2Bot;


    public TextMeshProUGUI card3LevelIncrease;
    public Image card3Bot;



    public Sprite nextLevelNormal;
    public Sprite nextLevelEneFuel;
    public Sprite nextLevelBombs;
    public Sprite nextLevelCrates;

    public Sprite upgradeBombBackground;
    public Sprite upgradeCrossBombBackground;
    public Sprite upgradePlusBombBackground;
    public Sprite upgradePlusBombbomb;
    public Sprite upgradeCrossBombbomb;
    public Sprite upgradeBombbomb;

    int card1LevelValue = 0;
    int card2LevelValue = 0;
    int card3LevelValue = 0;


    public Image card1BombImg;
    public Image card2BombImg;
    public Image card3BombImg;

    int card1LevelIncreaseValue = 0;
    int card2LevelIncreaseValue = 0;
    int card3LevelIncreaseValue = 0;

    int card1BombUpgradeValue = 0;
    int card2BombUpgradeValue = 0;
    int card3BombUpgradeValue = 0;


    string mainScene = "Gameplay";

    public List<Vector2> chainList = new List<Vector2>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameData.energy = 50;
        GameData.fuel = 0;
        GameData.bombAmount = 3;
        GameData.plusBombAmount = 3;
        GameData.crossBombAmount = 3;

        wall.transform.position = new Vector3(GameData.gridLenght - 2, 0, 0);
        background.transform.position = new Vector3((float)(GameData.gridLenght - 10) / 2, 0, 1);
        background.GetComponent<SpriteRenderer>().size = new Vector2(GameData.gridLenght + 8, 10);
    }

    // Update is called once per frame
    void Update()
    {
        loadWin();
    }

    //public void GameOver()
    //{
    //    if(GameData.energy <= 0 &GameData.fuel<= GameData.fuelToWin)
    //    {

    //    }
    //        Debug.Log("Game Over!");

    //}

    void loadWin()
    {
        if (GameData.fuel >= GameData.fuelToWin && !levelCards.activeSelf)
        {
            CreateLevelCards();
        }
    }
    string GetBombLevelText(int bombType)
    {
        switch (bombType)
        {
            case 0: // normal
                return GameData.bombLevel >= 3 ? "MAX" : GameData.bombLevel.ToString();

            case 1: // cross
                return GameData.crossBombLevel >= 3 ? "MAX" : GameData.crossBombLevel.ToString();

            case 2: // plus
                return GameData.plusBombLevel >= 3 ? "MAX" : GameData.plusBombLevel.ToString();

            default:
                return "";
        }
    }


    void CreateLevelCards()
    {
        levelCards.SetActive(true);

        card1LevelValue = Random.Range(0, 4);
        card1Top.sprite = GetNextLevelSprite(card1LevelValue);
        card2LevelValue = Random.Range(0, 4);
        card2Top.sprite = GetNextLevelSprite(card2LevelValue);
        card3LevelValue = Random.Range(0, 4);


        card1LevelIncreaseValue = Random.Range(1, 4);
        card1LevelIncrease.text = card1LevelIncreaseValue.ToString();
        card2LevelIncreaseValue = Random.Range(1, 4);
        card2LevelIncrease.text = card2LevelIncreaseValue.ToString();
        card3LevelIncreaseValue = Random.Range(1, 4);
        card3LevelIncrease.text = card3LevelIncreaseValue.ToString();

        card1BombUpgradeValue = Random.Range(0, 3);
        card1Bot.sprite = GetBombUpgradeSprite(card1BombUpgradeValue);
        card1BombImg.sprite = GetBombUpgradeBombSprite(card1BombUpgradeValue);
        card2BombUpgradeValue = Random.Range(0, 3);
        card2Bot.sprite = GetBombUpgradeSprite(card2BombUpgradeValue);
        card2BombImg.sprite = GetBombUpgradeBombSprite(card2BombUpgradeValue);
        card3BombUpgradeValue = Random.Range(0, 3);
        card3Bot.sprite = GetBombUpgradeSprite(card3BombUpgradeValue);
        card3BombImg.sprite = GetBombUpgradeBombSprite(card3BombUpgradeValue);


        card1BombLevelText.text = GetBombLevelText(card1BombUpgradeValue);
        card2BombLevelText.text = GetBombLevelText(card2BombUpgradeValue);
        card3BombLevelText.text = GetBombLevelText(card3BombUpgradeValue);
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
                return upgradeBombBackground;
            case 1:
                return upgradeCrossBombBackground;
            case 2:
                return upgradePlusBombBackground;
            default:
                return upgradeBombBackground;
        }
    }
    Sprite GetBombUpgradeBombSprite(int num)
    {
        switch (num)
        {
            case 0:
                return upgradeBombbomb;
            case 1:
                return upgradeCrossBombbomb;
            case 2:
                return upgradePlusBombbomb;
            default:
                return upgradeBombbomb;
        }
    }


    public void Card1Button()
    {
        SetLevelType(card1LevelValue);
        GameData.gridLenght += card1LevelIncreaseValue;
        UpgradeBomb(card1BombUpgradeValue);
        GameData.fuelToWin *= 2;

        //Debug.Log(card1LevelValue + " " + card1LevelIncreaseValue + " " + card1BombUpgradeValue);
        SceneManager.LoadScene(mainScene);
    }

    public void Card2Button()
    {
        SetLevelType(card2LevelValue);
        GameData.gridLenght += card2LevelIncreaseValue;
        UpgradeBomb(card2BombUpgradeValue);
        GameData.fuelToWin *= 2;

        //Debug.Log(card2LevelValue + " " + card2LevelIncreaseValue + " " + card2BombUpgradeValue);
        SceneManager.LoadScene(mainScene);
    }

    public void Card3Button()
    {
        SetLevelType(card3LevelValue);
        GameData.gridLenght += card3LevelIncreaseValue;
        UpgradeBomb(card3BombUpgradeValue);
        GameData.fuelToWin *= 2;

        //Debug.Log(card3LevelValue + " " + card3LevelIncreaseValue + " " + card3BombUpgradeValue);
        SceneManager.LoadScene(mainScene);
    }

    void UpgradeBomb(int num)
    {
        switch (num)
        {
            case 0:
                if (GameData.bombLevel < 3)
                    GameData.bombLevel++;

                Debug.Log("Bomb level: " + GameData.bombLevel);
                break;
            case 1:
                if (GameData.crossBombLevel < 3)
                    GameData.crossBombLevel++;

                Debug.Log("cross Bomb level: " + GameData.crossBombLevel);
                break;
            case 2:
                if (GameData.plusBombLevel < 3)

                    GameData.plusBombLevel++;

                Debug.Log("plus Bomb level: " + GameData.plusBombLevel);
                break;
            default:
                GameData.bombLevel++;
                break;
        }

    }


    void SetLevelType(int num)
    {
        switch (num)
        {
            case 0:
                GameData.levelType = LevelType.Normal;
                break;
            case 1:
                GameData.levelType = LevelType.EneFuel;
                break;
            case 2:
                GameData.levelType = LevelType.Bomb;
                break;
            case 3:
                GameData.levelType = LevelType.Crate;
                break;
            default:
                GameData.levelType = LevelType.Normal;
                break;
        }
    }


    public int StartChain()
    {
        if (chainList.Count == 0)
        {
            chainList.Add(new Vector2(1, 0));
            return 1;
        }
        else
        {
            int newID = 0;
            for (int i = 0; i < chainList.Count; i++)
            {
                if (chainList[i].x > newID) newID = (int)chainList[i].x;
            }
            newID++;
            chainList.Add(new Vector2(newID, 0));
            return newID;
        }

    }

    public int IncreaseChain(int chainID)
    {
        int maxChain = 0;
        for (int i = 0; i < chainList.Count; i++)
        {
            if (chainList[i].x == chainID && chainList[i].y > maxChain)
            {
                maxChain = (int)chainList[i].y;
            }
        }
        maxChain++;
        chainList.Add(new Vector2(chainID, maxChain));
        return maxChain;
    }

    public int GetChain(int chainID)
    {
        int maxChain = 0;
        for (int i = 0; i < chainList.Count; i++)
        {
            if (chainList[i].x == chainID && chainList[i].y > maxChain)
            {
                maxChain = (int)chainList[i].y;
            }
        }
        return maxChain;
    }

    public void DeleteChain(int chainID, int value)
    {
        for (int i = 0; i < chainList.Count; i++)
        {
            if (chainList[i].x == chainID && chainList[i].y == value)
            {
                chainList.RemoveAt(i);
                return;
            }
        }
    }
}
