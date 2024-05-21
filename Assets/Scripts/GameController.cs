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
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject monster5;
    public GameObject grid1;
    public GameObject grid2;
    public GameObject grid3;

    public int playerCounter;    // Setted in StartGamePageController by the Slider
    public int gridNum;
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
        HideAllGrids();
        HideAllPlayers();
        HideAllMonsters();
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
        switch (gridNum)
        {
            case 1:
                ShowGrid(grid1);
                break;
            case 2:
                ShowGrid(grid2);
                break;
            case 3:
                ShowGrid(grid3);
                break;
        }
        ShowAllMonsters();
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

    void HideAllGrids()
    {
        grid1.SetActive(false);
        grid2.SetActive(false);
        grid3.SetActive(false);
    }

    void HideAllMonsters()
    {
        monster1.SetActive(false);
        monster2.SetActive(false);
        monster3.SetActive(false);
        monster4.SetActive(false);
        monster5.SetActive(false);
    }

    void ShowPlayer(GameObject playerPrefab)
    {
        playerPrefab.SetActive(true);
    }

    void ShowGrid(GameObject grid)
    {
        grid.SetActive(true);
    }

    void ShowAllMonsters()
    {
        monster1.SetActive(true);
        monster2.SetActive(true);
        monster3.SetActive(true);
        monster4.SetActive(true);
        monster5.SetActive(true);
    }

    public void setPlayerCounter(int num)
    {
        playerCounter = num;
    }

    public int getGridNum()
    {
        return gridNum;
    }

    public void setGridNum(int num)
    {
        gridNum = num;
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
