using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton;
    public Button loadGameButton;
    public Button highScoreButton;

    public GameObject highScorePanel;
    public TextMeshProUGUI highScore1;
    public TextMeshProUGUI highScore2;
    public TextMeshProUGUI highScore3;
    public Button closeHighScoreButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newGameButton.onClick.AddListener(StartNewGame);
        loadGameButton.onClick.AddListener(LoadGame);
        highScoreButton.onClick.AddListener(ShowHighScore);
        closeHighScoreButton.onClick.AddListener(CloseHighScore);
    }

    void StartNewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    void LoadGame()
    {
        //SaveLoadManager.Instance.LoadData();
        SceneManager.LoadScene("Level" + GameData.level.ToString());
    }

    void ShowHighScore()
    {
        highScorePanel.SetActive(true);
        //int[] highScores = SaveLoadManager.Instance.LoadHighScore();

        //highScore1.text = highScores[0].ToString().PadLeft(4, '0');
        //highScore2.text = highScores[1].ToString().PadLeft(4, '0');
        //highScore3.text = highScores[2].ToString().PadLeft(4, '0');
    }

    void CloseHighScore()
    {
        highScorePanel.SetActive(false);
    }
}
