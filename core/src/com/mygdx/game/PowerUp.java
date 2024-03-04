package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.ScreenUtils;

public enum PowerUp {
    EXTRA_BOMB("Extra bomb", "Ads an extra bomb to your inventory"),
    EXPLOSION_RANGE_UP("Explosion range up", "Increase your bombs' explosion range by 1"),
    DECREASED_SPEED("Decreased speed", "Decreases player movement speed for a period of time"),
    SHORT_RANGE_BOMB("Short range bomb", "Reduces bomb explosion range for a period of time"),
    NO_BOMB("No bomb", "Prevents the player from placing bombs for a period of time"),
    INSTANT_BOMB_PLACEMENT("Instant bomb placement", "Automaticly place bombs when it's possible for a period of time");

    private final String name;
    private final String description;

    PowerUp(String name, String description){
        this.name = name;
        this.description = description;
    }
    public String getName() {
        return name;
    }
    public String getDescription() {
        return description;
    }
}