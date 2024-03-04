package com.mygdx.game;

import java.util.Random;

public class Box{
    private final String texture = "box.png"

    public Box(){}
    public Box(String texture){
        this.texture = texture;
    }

    public PowerUp break(){
        PowerUp[] powerUps = PowerUp.values();
        return powerUps[new Random().nextInt(powerUps.length)];
    }
}