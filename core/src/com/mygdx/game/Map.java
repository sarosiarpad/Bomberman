package com.mygdx.game;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Map {
    private static int width = Settings.getScreenWidth();
    private static int height = Settings.getScreenHeight();

    public static void generateMap(List<Wall> walls, List<Box> boxes) throws IOException {
        BufferedReader reader = new BufferedReader(new FileReader("assets/maps/map1.txt"));
        String line;
        int x = 0;
        while ((line = reader.readLine()) != null) {
            String[] tiles = line.split("");
            int y = 0;
            for (String tile : tiles) {
                switch (tile) {
                    case "1":
                        walls.add(new Wall(x * (height/12), y * (height/12), (height/12)));
                        break;
                    case "2":
                        boxes.add(new Box(x * (height/12), y * (height/12), (height/12)));
                        break;
                    default:
                        // Ha az érték nem 1 vagy 2, nincs semmi teendő
                        break;
                }
                y++;
            }
            x++;
        }
        reader.close();
    }
}
