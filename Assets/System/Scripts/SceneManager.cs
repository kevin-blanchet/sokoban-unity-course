using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void toMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void toLevel(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level" + level);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
