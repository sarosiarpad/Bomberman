package com.mygdx.game;

public class Settings {
    private static int screenWidth = 1280;
    private static int screenHeight = 720;
    private static boolean fullscreen = false;

    public static void setScreen(){
        screenWidth = 1280;
        screenHeight = 720;
        fullscreen = false;
    }

    public static void setScreen(int width, int height, boolean isFullscreen){
        screenWidth = width;
        screenHeight = height;
        fullscreen = isFullscreen;
    }

    public static int getScreenWidth() {
        return screenWidth;
    }
    public static int getScreenHeight() {
        return screenHeight;
    }
    public static boolean isFullscreen() {
        return fullscreen;
    }
}
