using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject player3Prefab;

    public void StartNewGame(int players)
    {
        HideAllPlayers();
        // Megjelenítjük azokat a játékos prefabokat, amelyek szükségesek
        switch (players)
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

        // Játék betöltése
        SceneManager.LoadScene("Bomberman");
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
}
