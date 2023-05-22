using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MPlay;
    public GameObject MLevels;
    public GameObject MExit;
    public GameObject ButtonsExit;
    public GameObject ButtonsLevels;
    public GameObject ButtonInf;

    public void ShowExitButtons()
    {
        MExit.SetActive(false);
        MPlay.SetActive(false);
        MLevels.SetActive(false);
        ButtonsExit.SetActive(true);
        Debug.Log("Exit");
    }

    public void BackInMenuLevels()
    {
        MExit.SetActive(true);
        MPlay.SetActive(true);
        MLevels.SetActive(true);
        ButtonsLevels.SetActive(false);
        Debug.Log("MenuL");
    }

    public void BackInMenu()
    {
        MExit.SetActive(true);
        MPlay.SetActive(true);
        MLevels.SetActive(true);
        ButtonsExit.SetActive(false);
        Debug.Log("MenuE");
    }

    public void ShowLevels()
    {
        MExit.SetActive(false);
        MPlay.SetActive(false);
        MLevels.SetActive(false);
        ButtonsLevels.SetActive(true);
        Debug.Log("Levels");
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Play1Level()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayBeskonechGame()
    {
        SceneManager.LoadScene(11);
    }
}
