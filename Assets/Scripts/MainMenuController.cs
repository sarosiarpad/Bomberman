using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainPage;
    public GameObject StartGamePage;

    private void Start()
    {
        MainPage.SetActive(true);
        StartGamePage.SetActive(false);
    }

    public void PlayGame()
    {
        MainPage.SetActive(false);
        StartGamePage.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        MainPage.SetActive(true);
        StartGamePage.SetActive(false);
    }
}
