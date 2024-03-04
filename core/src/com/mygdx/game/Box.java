package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.*;
import com.badlogic.gdx.utils.ScreenUtils;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import java.util.Random;

public class Box extends Sprite {
    private PowerUp powerup;
    public Box(int x, int y) {
        super(new Texture("box.png"), 50, 50);
        setPosition(x, y);

        PowerUp[] powerups = PowerUp.values();
        Random random = new Random();
        this.powerup = powerups[random.nextInt(powerups.length)];
    }
    public PowerUp getPowerUp() {
        return this.powerup;
    }
}
