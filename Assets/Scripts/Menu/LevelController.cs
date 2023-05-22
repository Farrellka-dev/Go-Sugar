using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instace = null;
    int sceneIndex;
    int levelComplite;

    void Start()
    {
        if (instace == null)
        {
            instace = this;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplite = PlayerPrefs.GetInt("LevelComplite");
    }

    public void isEndGame()
    {
        if (sceneIndex == 10)
        {
            Invoke("Menu", 0.1f);
        }
        else
        {
            if (levelComplite < sceneIndex)
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            Invoke("NextLevel", 0.1f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
