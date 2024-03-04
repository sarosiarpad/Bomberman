package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.ScreenUtils;

public class BombermanGame extends ApplicationAdapter {
	SpriteBatch batch;
	Texture img;
	Wall[] walls;
	Box[] boxes;
	
	@Override
	public void create () {
		batch = new SpriteBatch();

		// Falak inicializálása
		walls = new Wall[3];
		walls[0] = new Wall(100, 150);
		walls[1] = new Wall(150, 150);
		walls[2] = new Wall(150, 200);

		// Dobozok inicializálása
		boxes = new Box[3];
		boxes[0] = new Box(100, 200);
		boxes[1] = new Box(200, 300);
		boxes[2] = new Box(300, 400);
	}

	@Override
	public void render () {
		ScreenUtils.clear(1, 0, 0, 1);
		batch.begin();

		for (Wall wall : walls) {
			batch.draw(
					wall.getTexture(),
					wall.getX(),
					wall.getY(),
					wall.getWidth(),
					wall.getHeight()
			);
		}

		// Dobozok megjelenítése
		for (Box box : boxes) {
			batch.draw(
					box.getTexture(),
					box.getX(),
					box.getY(),
					box.getWidth(),
					box.getHeight()
			);
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
