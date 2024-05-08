using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject game;
    public GameObject gameOver;
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject player3Prefab;

    public int playerCounter;    // Setted in StartGamePageController by the Slider
    public string outcome = "";

    private void Start()
    {
        mainMenu.SetActive(true);
        game.SetActive(false);
        gameOver.SetActive(false);
    }

    public void BacktoMain()
    {
        mainMenu.SetActive(true);
        game.SetActive(false);
        gameOver.SetActive(false);
    }

    public void StartNewGame()
    {
        HideAllPlayers();
        switch (playerCounter)
        {
            case 2:
                ShowPlayer(player1Prefab);
                ShowPlayer(player2Prefab);
                break;
            case 3:
                ShowPlayer(player1Prefab);
                ShowPlayer(player2Prefab);
                ShowPlayer(player3Prefab);
                break;
        }

        mainMenu.SetActive(false);
        game.SetActive(true);
        gameOver.SetActive(false);
    }

    public void checkGameOver()
    {
        int aliveCounter = 0;

        if (player1Prefab.activeSelf)
        {
            aliveCounter++;
            outcome = "Player 1 wins";
        }
        if (player2Prefab.activeSelf)
        {
            aliveCounter++;
            outcome = "Player 2 wins!";
        }
        if (player3Prefab.activeSelf)
        {
            aliveCounter++;
            outcome = "Player 3 wins!";
        }

        if(aliveCounter == 0)
        {
            outcome = "Draw!";
            mainMenu.SetActive(false);
            game.SetActive(false);
            gameOver.SetActive(true);
        }
        else if(aliveCounter == 1)
        {
            mainMenu.SetActive(false);
            game.SetActive(false);
            gameOver.SetActive(true);
        }
    }

    void HideAllPlayers()
    {
        player1Prefab.SetActive(false);
        player2Prefab.SetActive(false);
        player3Prefab.SetActive(false);
    }

    void ShowPlayer(GameObject playerPrefab)
    {
        playerPrefab.SetActive(true);
    }

    public void setPlayerCounter(int num)
    {
        playerCounter = num;
    }

    public int getPlayerCounter()
    {
        return playerCounter;
    }

    public string getOutcome()
    {
        return outcome;
    }
}
