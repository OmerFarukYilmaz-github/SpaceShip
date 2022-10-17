using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
