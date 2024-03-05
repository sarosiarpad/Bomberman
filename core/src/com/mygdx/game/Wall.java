package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.*;
import com.badlogic.gdx.utils.ScreenUtils;

public class Wall extends Sprite{
    public Wall(int x, int y){
        super(new Texture("wall.png"), 50, 50);
        setPosition(x, y);
    }
}