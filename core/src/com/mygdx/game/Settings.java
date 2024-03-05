package com.mygdx.game;

public class Settings {
    private static int screenWidth;
    private static int screenHeight;

    public static void setScreen(){
        screenWidth = 1280;
        screenHeight = 720;
    }

    public static void setScreen(int w, int h){
        screenWidth = w;
        screenHeight = h;
    }

    public static int getScreenWidth() {
        return screenWidth;
    }
    public static int getScreenHeight() {
        return screenHeight;
    }
}
