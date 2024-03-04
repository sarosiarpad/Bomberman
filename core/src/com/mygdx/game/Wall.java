package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.ScreenUtils;
import com.badlogic.gdx.graphics.g2d.TextureRegion;

public class Wall{
    private boolean breakable = false;
    public Wall(Texture texture){
        super(texture);
    }
    public boolean getBreakable() { return breakable; }
}