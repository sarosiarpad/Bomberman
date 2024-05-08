using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public GameController gameController;
    public Text outcome;
    public Button backToMainButton;
    public string outcomeText;

    void Start()
    {
        backToMainButton.onClick.AddListener(onBackToMainButtonClicked);
    }

    private void Update()
    {
        outcomeText = gameController.getOutcome();
        outcome.text = outcomeText;
    }

    void onBackToMainButtonClicked()
    {
        SceneManager.LoadScene("Bomberman");        // must be reloaded the whole Scene, otherwise the Players state won't change (dead players stay dead)
    }
}
