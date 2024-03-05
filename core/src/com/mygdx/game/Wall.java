package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.*;
import com.badlogic.gdx.utils.ScreenUtils;

public class Wall extends Sprite{
    public Wall(int x, int y, int size){
        super(new Texture("wall.png"), size, size);
        setPosition(x, y);
    }
}