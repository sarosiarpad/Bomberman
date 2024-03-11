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
	Map map = new Map("assets/maps/map1.txt");
	List<Wall> walls = new ArrayList<>();
	List<Box> boxes = new ArrayList<>();
	List<Player> players = new ArrayList<>();
	
	@Override
	public void create () {
		batch = new SpriteBatch();

		int[][] raw = map.getRaw();

		try {
			map.generate(walls, boxes);
		} catch (IOException e) {
			throw new RuntimeException(e);
		}

		for (int i = 0; i < 1; ++i) {
			players.add(new Player(10,1,null, raw));
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
		for( Player player : players) {
			batch.draw(player.getTexture(), player.getX(), player.getY(), player.getWidth(), player.getHeight());
		}

        batch.end();
	}
	
	@Override
	public void dispose () {
		batch.dispose();
		for (Wall wall : walls) {
			wall.getTexture().dispose();
		}
		for(Box box : boxes){
			box.getTexture().dispose();
		}
	}
}
