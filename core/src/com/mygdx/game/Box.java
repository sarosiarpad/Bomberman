package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.ScreenUtils;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import java.util.Random;

public class Box extends Sprite {
    private PowerUp powerup;
    private final int width = 100;
    private final int height = 100;
    private int x;
    private int y;

    public Box(int x, int y) {
        super(new Texture("textures/box.png"));
        setPosition(x, y);
        setBounds(x, y, width, height);

        PowerUp[] powerups = new PowerUp.values();
        Random random = new Random();
        powerup = powerups[random.nextInt(powerups.length)];
    }
    public PowerUp getPowerUp() {
        return powerUp;
    }
}
