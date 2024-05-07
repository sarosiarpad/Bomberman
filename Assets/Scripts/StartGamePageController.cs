using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGamePageController : MonoBehaviour
{

    public Button StartNewGameButton;
    public Slider slider;
    public GameController gameController;

    private int playerCount;
    
    void Start()
    {
        slider.minValue = 2;
        slider.maxValue = 3;
        slider.value = playerCount = 2;

        slider.onValueChanged.AddListener(onSliderValueChanged);
        StartNewGameButton.onClick.AddListener(OnStartGameButtonClick);
    }

    void onSliderValueChanged(float value)
    {
        playerCount = (int)value;
    }

    void OnStartGameButtonClick()
    {
        Debug.Log("clicked");
        gameController.StartNewGame(playerCount);
    }
}
