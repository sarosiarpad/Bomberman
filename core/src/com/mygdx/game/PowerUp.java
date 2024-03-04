package com.mygdx.game;

public enum PowerUp{
    EXTRA_BOMB(
            "Extra bomb",
            "Ads an extra bomb to your inventory",
            "extrabomb.png"
    ),
    EXPLOSION_RANGE_UP(
            "Explosion range up",
            "Increase your bombs' explosion range by 1",
            "explosionrangeup.png"
    ),
    DECREASED_SPEED(
            "Decreased speed",
            "Decreases player movement speed for a period of time",
            "decreasedspeed.png"
    ),
    SHORT_RANGE_BOMB(
            "Short range bomb",
            "Reduces bomb explosion range for a period of time",
            "shortrangebomb.png"
    ),
    NO_BOMB(
            "No bomb",
            "Prevents the player from placing bombs for a period of time",
            "nobomb.png"
    ),
    INSTANT_BOMB_PLACEMENT(
            "Instant bomb placement",
            "Automaticly place bombs when it's possible for a period of time",
            "instantbombplacement.png"
    );

    private final String name;
    private final String description;
    private final String textureName;

    PowerUp(String name, String description, String textureName){
        this.name = name;
        this.description = description;
        this.textureName = textureName;
    }

    public String getName() {
        return name;
    }

    public String getDescription() {
        return description;
    }

    public String getTextureName() {
        return textureName;
    }
}