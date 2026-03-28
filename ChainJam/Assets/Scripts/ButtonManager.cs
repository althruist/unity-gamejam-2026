using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    [SerializeField] private string gameScreen = "SampleScene";
    [SerializeField] private string mainMenuScreen = "MainMenu";

    public void enterGameScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameScreen);
    }

    public void enterMainMenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScreen);
    }
}
