using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGamePageController : MonoBehaviour
{
    public MainMenuController mainMenuController;
    public GameController gameController;
    public Button StartNewGameButton;
    public Slider slider;
    public Button BackToMainButton;
    
    void Start()
    {
        slider.minValue = 2;
        slider.maxValue = 3;
        slider.value =  2;

        StartNewGameButton.onClick.AddListener(onStartNewGameButtonClick);
        slider.onValueChanged.AddListener(onSliderValueChanged);
        BackToMainButton.onClick.AddListener(onBackToMainClick);
    }

    public void onSliderValueChanged(float value)
    {
        slider.value = (int)value;
    }

    public void onStartNewGameButtonClick()
    {
        int playerCount = (int)slider.value;
        gameController.setPlayerCounter(playerCount);
        gameController.StartNewGame();
    }

    public void onBackToMainClick()
    {
        gameController.BacktoMain();
        mainMenuController.BackToMain();
    }
}
