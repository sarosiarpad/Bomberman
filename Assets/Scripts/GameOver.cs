using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text winnerText;

    public void Setup(string player)
    {
        winnerText.text = player + "wins!";
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Bomberman");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
