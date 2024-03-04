package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.ScreenUtils;

public class Box extends Sprite{

    private boolean breakable = true;
    public Box(Texture texture){
        super(texture);
    }
    public boolean getBreakable() { return breakable; }


}