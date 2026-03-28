using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    [SerializeField] private string gameScreen = "Gameplay";
    [SerializeField] private string mainMenuScreen = "MainMenu";

    private IEnumerator StartGame()
    {
        CinematicLetterbox.Instance.active = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(gameScreen);
    }

    private IEnumerator StartMenu()
    {
        CinematicLetterbox.Instance.active = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(mainMenuScreen);
    }

    public void enterGameScene()
    {
        StartCoroutine(StartGame());
    }

    public void enterMainMenuScene()
    {
        StartCoroutine(StartMenu());
    }

    public void Quit()
    {
        Debug.Log("Quit");

        Application.Quit();
    }
}
