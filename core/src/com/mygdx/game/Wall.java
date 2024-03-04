package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.ScreenUtils;
import com.badlogic.gdx.graphics.g2d.TextureRegion;

public class Wall{
    private final int width = 100;
    private final int height = 100;
    private int x;
    private int y;

    public Wall(int x, int y){
        super(new Texture("textures/wall.png"));
        setPosition(x, y);
        setBounds(x, y, width, height);
    }
}