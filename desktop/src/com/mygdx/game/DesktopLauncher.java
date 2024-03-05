package com.mygdx.game;

import com.badlogic.gdx.Graphics;
import com.badlogic.gdx.backends.lwjgl3.Lwjgl3Application;
import com.badlogic.gdx.backends.lwjgl3.Lwjgl3ApplicationConfiguration;
import com.mygdx.game.BombermanGame;

// Please note that on macOS your application needs to be started with the -XstartOnFirstThread JVM argument
public class DesktopLauncher {
	public static void main (String[] arg) {
		Lwjgl3ApplicationConfiguration config = new Lwjgl3ApplicationConfiguration();

		config.setForegroundFPS(60);
		config.setTitle("Bomberman");

		Settings.setScreen();

		if(Settings.isFullscreen()){
			config.setFullscreenMode(Lwjgl3ApplicationConfiguration.getDisplayMode());
		}else{
			config.setWindowedMode(Settings.getScreenWidth(), Settings.getScreenHeight());
		}

		config.setWindowedMode(Settings.getScreenWidth(), Settings.getScreenHeight());

		new Lwjgl3Application(new BombermanGame(), config);
	}
}
