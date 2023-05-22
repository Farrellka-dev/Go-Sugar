using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject gameObjects;
    public GameObject pauseMenuUI;
    public GameObject gameInterface;
    public GameObject buttonLevels;
    public GameObject buttonsMenu;
    public GameObject buttonsLevels;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        gameInterface.SetActive(true);
        pauseMenuUI.SetActive(false);
        gameObjects.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

   public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameInterface.SetActive(false);
        gameObjects.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void  LoadMenu()
    {
        Debug.Log("Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void LoadLevels()
    {
        Debug.Log("Levels");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
