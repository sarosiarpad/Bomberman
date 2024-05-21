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
    public Slider PlayerSlider;
    public Slider GridSlider;
    public Button BackToMainButton;
    
    void Start()
    {
        PlayerSlider.minValue = 2;
        PlayerSlider.maxValue = 3;
        PlayerSlider.value =  2;

        StartNewGameButton.onClick.AddListener(onStartNewGameButtonClick);
        PlayerSlider.onValueChanged.AddListener(onPlayerSliderValueChange);
        GridSlider.onValueChanged.AddListener(onGridSliderValueChange);
        BackToMainButton.onClick.AddListener(onBackToMainClick);
    }

    public void onPlayerSliderValueChange(float value)
    {
        PlayerSlider.value = (int)value;
    }

    public void onGridSliderValueChange(float value)
    {
        GridSlider.value = (int)value;
    }

    public void onStartNewGameButtonClick()
    {
        int playerCount = (int)PlayerSlider.value;
        int gridNum = (int)GridSlider.value;
        gameController.setPlayerCounter(playerCount);
        gameController.setGridNum(gridNum);
        gameController.StartNewGame();
    }

    public void onBackToMainClick()
    {
        gameController.BacktoMain();
        mainMenuController.BackToMain();
    }
}
