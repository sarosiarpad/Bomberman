package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.InputProcessor;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Sprite;
import com.badlogic.gdx.math.Vector2;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Set;

public class Player extends Sprite implements InputProcessor  {
    private int bombCount;
    private float speed;
    private Vector2 position;
    private int row;
    private int col;
    private List<PowerUp> powerUps;
    private boolean alive;

    private final int[][] rawMap;
    private final HashMap<Direction, Integer> keys;

    public Player(int bombCount, float speed, Vector2 position, int[][] rawMap) {
        super(new Texture("player.png"), Map.BLOCK_SIZE,Map.BLOCK_SIZE);

        col = 3 * Map.BLOCK_SIZE;
        row = 4 * Map.BLOCK_SIZE;
        this.setPosition(col,row);

        this.bombCount = bombCount;
        this.speed = speed;
        this.position = position;
        this.powerUps = new ArrayList<PowerUp>();
        this.alive = true;

        this.rawMap = rawMap;

        this.keys = new HashMap<>();
        this.keys.put(Direction.UP, Input.Keys.W);
        this.keys.put(Direction.DOWN, Input.Keys.S);
        this.keys.put(Direction.LEFT, Input.Keys.A);
        this.keys.put(Direction.RIGHT, Input.Keys.D);
    }

    public void move(Direction direction) {
        switch (direction) {
            case UP:
                position.y += speed;
                break;
            case DOWN:
                position.y -= speed;
                break;
            case LEFT:
                position.x -= speed;
                break;
            case RIGHT:
                position.x += speed;
                break;
        }
    }    

    public void placeBomb() {
    }

    public void die() {
        alive = false;
    }

    public int getBombCount() {
        return bombCount;
    }

    public void setBombCount(int bombCount) {
        this.bombCount = bombCount;
    }

    public float getSpeed() {
        return speed;
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    public Vector2 getPosition() {
        return position;
    }

    public void setPosition(Vector2 position) {
        this.position = position;
    }

    public List<PowerUp> getPowerUps() {
        return powerUps;
    }

    public void setPowerUps(List<PowerUp> powerUps) {
        this.powerUps = powerUps;
    }

    public boolean isAlive() {
        return alive;
    }

    public void setAlive(boolean alive) {
        this.alive = alive;
    }

    /**
     * @param col oszlop-index
     * @param row sor-index
     * @return Szabad-e mozogni az adott blokk-ra
     * */
    private boolean validMove(int col, int row) {
        return rawMap[col][row] != 1 && rawMap[col][row]  != 2;
    }

    @Override
    public boolean keyDown(int keycode) {
        if (Gdx.input.isKeyPressed(this.keys.get(Direction.UP))) {
            if (validMove(col,row)) {
                col -= (int) speed;
            }
            this.setPosition(col,row);
        }
        else if (Gdx.input.isKeyPressed(this.keys.get(Direction.DOWN))) {
            if (validMove(col,row)) {
                col += (int) speed;
            }
            this.setPosition(col,row);
        }
        else if (Gdx.input.isKeyPressed(this.keys.get(Direction.LEFT))) {
            if (validMove(col,row)) {
                row -= (int) speed;
            }
            this.setPosition(col,row);
        }
        else if (Gdx.input.isKeyPressed(this.keys.get(Direction.RIGHT))) {
            if (validMove(col,row)) {
                row += (int) speed;
            }
            this.setPosition(col,row);
        }
        return true;
    }

    @Override
    public boolean keyUp(int i) {
        return false;
    }

    @Override
    public boolean keyTyped(char c) {
        return false;
    }

    @Override
    public boolean touchDown(int i, int i1, int i2, int i3) {
        return false;
    }

    @Override
    public boolean touchUp(int i, int i1, int i2, int i3) {
        return false;
    }

    @Override
    public boolean touchCancelled(int i, int i1, int i2, int i3) {
        return false;
    }

    @Override
    public boolean touchDragged(int i, int i1, int i2) {
        return false;
    }

    @Override
    public boolean mouseMoved(int i, int i1) {
        return false;
    }

    @Override
    public boolean scrolled(float v, float v1) {
        return false;
    }
}
