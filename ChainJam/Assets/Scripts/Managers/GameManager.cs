using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    public GameObject wall;
    public GameObject background;

    public GameObject levelCards;
    public int currentChain;
    public GameState gameState;
    public AudioClip ambience;
    public TextMeshProUGUI card1BombLevelText;
    public TextMeshProUGUI card2BombLevelText;
    public TextMeshProUGUI card3BombLevelText;
    public TextMeshPro tileExplosionText;

    public TextMeshProUGUI card1LevelIncrease;
    public TextMeshProUGUI card2LevelIncrease;
    public TextMeshProUGUI card3LevelIncrease;


    public TextMeshProUGUI card1Leveldescription;
    public TextMeshProUGUI card2Leveldescription;
    public TextMeshProUGUI card3Leveldescription;


    public int remainingFuelTiles;


    bool losePending = false;


    public Sprite nextLevelNormal;
    public Sprite nextLevelEneFuel;
    public Sprite nextLevelBombs;
    public Sprite nextLevelCrates;


    public Sprite upgradePlusBombbomb;
    public Sprite upgradeCrossBombbomb;
    public Sprite upgradeBombbomb;

    int card1LevelValue = 0;
    int card2LevelValue = 0;
    int card3LevelValue = 0;

    public GameObject card1;
    public GameObject card2;
    public GameObject card3;

    public Image card1BombImg;
    public Image card2BombImg;
    public Image card3BombImg;

    public Image card1nextlevelimg;
    public Image card2nextlevelimg;
    public Image card3nextlevelimg;

    int card1LevelIncreaseValue = 0;
    int card2LevelIncreaseValue = 0;
    int card3LevelIncreaseValue = 0;

    int card1BombUpgradeValue = 0;
    int card2BombUpgradeValue = 0;
    int card3BombUpgradeValue = 0;


    string mainScene = "Gameplay";
    string loseScene = "LoseScene";

    public List<Vector2> chainList = new List<Vector2>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("GameManager START");

        ResetOilOnly();

        gameObject.GetComponent<AudioSource>().clip = ambience;
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();
        remainingFuelTiles = FindObjectsByType<FuelTile>(FindObjectsSortMode.None).Length;
        Debug.Log("Starting fuel tiles: " + remainingFuelTiles);


        gameState = GameState.Playing;
        Debug.Log("Game State set to PLAYING");



        wall.transform.position = new Vector3(GameData.gridLenght - 2, 0, 0);
        background.transform.position = new Vector3((float)(GameData.gridLenght - 10) / 2, 0, 1);
        background.GetComponent<SpriteRenderer>().size = new Vector2(GameData.gridLenght + 8, 10);

        Debug.Log("Grid Length: " + GameData.gridLenght);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != GameState.Playing) return;

        LoadWin();

        // IMPORTANT: don't allow lose check if win already triggered
        if (gameState != GameState.Win)
        {
            CheckLose();
        }
    }
    void CheckLose()
    {
        if (remainingFuelTiles <= 0 && GameData.fuel < GameData.fuelToWin)
        {
            if (!losePending)
            {
                losePending = true;
                StartCoroutine(LoseDelay());
            }
        }
    }

    IEnumerator LoseDelay()
    {
        yield return new WaitForSeconds(0.5f);

        // Re-check AFTER delay (important!)
        if (GameData.fuel < GameData.fuelToWin)
        {
            Debug.Log("YOU LOSE");
            ResetAllStats();
            gameState = GameState.GameOver;
            SceneManager.LoadScene(loseScene);
        }

        losePending = false;
    }



    void ResetOilOnly()
    {
        GameData.fuel = 0;
    }


    void ResetAllStats()
    {
        GameData.energy = 50;
        GameData.fuel = 0;
        GameData.gridLenght = 10; // set your default starting value
        GameData.fuelToWin = 200;  // set your default starting value

        GameData.bombLevel = 1;
        GameData.crossBombLevel = 1;
        GameData.plusBombLevel = 1;

        GameData.bombAmount = 3;
        GameData.plusBombAmount = 3;
        GameData.crossBombAmount = 3;

        GameData.levelType = LevelType.Normal;

        chainList.Clear();

        Debug.Log("ALL STATS RESET (Lose Condition)");
    }

    void CreateLevelCards()
    {
        Debug.Log("Creating Level Cards...");

        levelCards.SetActive(true);

        card1.GetComponent<Animator>().SetTrigger("Appear");
        card2.GetComponent<Animator>().SetTrigger("Appear");
        card3.GetComponent<Animator>().SetTrigger("Appear");

        card1LevelValue = Random.Range(0, 11);
        card2LevelValue = Random.Range(0, 11);
        card3LevelValue = Random.Range(0, 11);

        Debug.Log($"Card Types: [{card1LevelValue}, {card2LevelValue}, {card3LevelValue}]");

        card1LevelIncreaseValue = Random.Range(1, 4);
        card2LevelIncreaseValue = Random.Range(1, 4);
        card3LevelIncreaseValue = Random.Range(1, 4);

        Debug.Log($"Level Increase: [{card1LevelIncreaseValue}, {card2LevelIncreaseValue}, {card3LevelIncreaseValue}]");

        card1BombUpgradeValue = Random.Range(0, 3);
        card2BombUpgradeValue = Random.Range(0, 3);
        card3BombUpgradeValue = Random.Range(0, 3);

        Debug.Log($"Bomb Upgrades: [{card1BombUpgradeValue}, {card2BombUpgradeValue}, {card3BombUpgradeValue}]");




        card1LevelIncrease.text = "level Size + " + card1LevelIncreaseValue.ToString();

        card2LevelIncrease.text = "level Size + " + card2LevelIncreaseValue.ToString();

        card3LevelIncrease.text = "level Size + " + card3LevelIncreaseValue.ToString();



        card1BombImg.sprite = GetBombUpgradeBombSprite(card1BombUpgradeValue);

        card2BombImg.sprite = GetBombUpgradeBombSprite(card2BombUpgradeValue);

        card3BombImg.sprite = GetBombUpgradeBombSprite(card3BombUpgradeValue);


        card1BombLevelText.text = GetBombLevelText(card1BombUpgradeValue);
        card2BombLevelText.text = GetBombLevelText(card2BombUpgradeValue);
        card3BombLevelText.text = GetBombLevelText(card3BombUpgradeValue);



        card1nextlevelimg.sprite = GetNextLevelSprite(card1LevelValue);
        card2nextlevelimg.sprite = GetNextLevelSprite(card2LevelValue);
        card3nextlevelimg.sprite = GetNextLevelSprite(card3LevelValue);


        card1Leveldescription.text = GetLevelDescription(card1LevelValue);
        card2Leveldescription.text = GetLevelDescription(card2LevelValue);
        card3Leveldescription.text = GetLevelDescription(card3LevelValue);
    }
    string GetBombLevelText(int upgradeType)
    {
        int level = 0;

        switch (upgradeType)
        {
            case 0:
                level = GameData.bombLevel;
                break;
            case 1:
                level = GameData.crossBombLevel;
                break;
            case 2:
                level = GameData.plusBombLevel;
                break;
        }

        if (level >= 3)
            return "MAX";

        return "Level Up";
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
        Debug.Log("Card 1 Selected");
        if (gameState != GameState.Win) return;

        gameState = GameState.Transition;



        Debug.Log($"Before -> Grid: {GameData.gridLenght}, FuelToWin: {GameData.fuelToWin}");

        SetLevelType(card1LevelValue);
        GameData.gridLenght += card1LevelIncreaseValue;
        UpgradeBomb(card1BombUpgradeValue);
        GameData.fuelToWin *= 2;


        Debug.Log($"After -> Grid: {GameData.gridLenght}, FuelToWin: {GameData.fuelToWin}");

        SceneManager.LoadScene(mainScene);
    }

    public void Card2Button()
    {
        Debug.Log("Card 2 Selected");
        if (gameState != GameState.Win) return;

        gameState = GameState.Transition;

        Debug.Log($"Before -> Grid: {GameData.gridLenght}, FuelToWin: {GameData.fuelToWin}");

        SetLevelType(card2LevelValue);
        GameData.gridLenght += card2LevelIncreaseValue;
        UpgradeBomb(card2BombUpgradeValue);
        GameData.fuelToWin *= 2;

        Debug.Log($"After -> Grid: {GameData.gridLenght}, FuelToWin: {GameData.fuelToWin}");

        SceneManager.LoadScene(mainScene);
    }

    public void Card3Button()
    {
        Debug.Log("Card 3 Selected");
        if (gameState != GameState.Win) return;

        gameState = GameState.Transition;

        Debug.Log($"Before -> Grid: {GameData.gridLenght}, FuelToWin: {GameData.fuelToWin}");

        SetLevelType(card3LevelValue);
        GameData.gridLenght += card3LevelIncreaseValue;
        UpgradeBomb(card3BombUpgradeValue);
        GameData.fuelToWin *= 2;
        Debug.Log($"After -> Grid: {GameData.gridLenght}, FuelToWin: {GameData.fuelToWin}");


        //Debug.Log(card3LevelValue + " " + card3LevelIncreaseValue + " " + card3BombUpgradeValue);
        SceneManager.LoadScene(mainScene);
    }

    void UpgradeBomb(int num)
    {
        Debug.Log("Upgrading Bomb Type: " + num);

        switch (num)
        {
            case 0:
                if (GameData.bombLevel < 3)
                    GameData.bombLevel++;

                Debug.Log("Bomb Level now: " + GameData.bombLevel);
                break;

            case 1:
                if (GameData.crossBombLevel < 3)
                    GameData.crossBombLevel++;

                Debug.Log("Cross Bomb Level now: " + GameData.crossBombLevel);
                break;

            case 2:
                if (GameData.plusBombLevel < 3)
                    GameData.plusBombLevel++;

                Debug.Log("Plus Bomb Level now: " + GameData.plusBombLevel);
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


    void LoadWin()
    {
        if (GameData.fuel >= GameData.fuelToWin && !levelCards.activeSelf)
        {
            Debug.Log($"WIN CONDITION MET -> Fuel: {GameData.fuel}/{GameData.fuelToWin}");

            gameState = GameState.Win;
            ResetOilOnly();
            Debug.Log("Game State set to WIN");

            CreateLevelCards();
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
    string GetLevelDescription(int levelType)
    {
        switch (levelType)
        {
            case 0:
                return "Standard level with normal tiles.";
            case 1:
                return "More energy & fuel spawns.";
            case 2:
                return "More bombs available.";
            case 3:
                return "More crates to destroy.";
            default:
                return "Standard level with normal tiles";
        }
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
