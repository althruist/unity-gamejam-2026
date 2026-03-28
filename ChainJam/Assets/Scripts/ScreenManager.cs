using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    // Call lose screen when energy is 0 or less
        void Update()
        {
            loadLoseScreen();
    }

        void loadLoseScreen()
        {
            if (GameData.energy <= 0)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("LoseScene");
            }
        }
}
