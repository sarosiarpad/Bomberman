package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.ScreenUtils;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class BombermanGame extends ApplicationAdapter {
	SpriteBatch batch;
	Texture img;
	List<Wall> walls = new ArrayList<>();
	List<Box> boxes = new ArrayList<>();
	
	@Override
	public void create () {
		batch = new SpriteBatch();
		try {
			Map.generateMap(walls, boxes);
		} catch (IOException e) {
			throw new RuntimeException(e);
		}
	}

	@Override
	public void render () {
		ScreenUtils.clear(0, 0, 0, 0);
		batch.begin();

		for(Wall wall : walls){
			batch.draw(wall.getTexture(), wall.getX(), wall.getY(), wall.getWidth(), wall.getHeight());
		}
		for(Box box : boxes){
			batch.draw(box.getTexture(), box.getX(), box.getY(), box.getWidth(), box.getHeight());
		}

        batch.end();
	}
	
	@Override
	public void dispose () {
		batch.dispose();
		img.dispose();
		for (Wall wall : walls) {
			wall.getTexture().dispose();
		}
		for(Box box : boxes){
			box.getTexture().dispose();
		}
	}
}
