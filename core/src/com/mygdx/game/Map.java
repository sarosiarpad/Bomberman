package com.mygdx.game;

import com.badlogic.gdx.math.Vector2;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Map {
    private static int width = Settings.getScreenWidth();
    private static int height = Settings.getScreenHeight();
    public static final int BLOCK_SIZE = height / 12;

    private final int[][] raw;

    public Map(String mapFileName) {
        raw = parseFile(mapFileName);
    }

    private int[][] parseFile(String fileName) {
        int[][] rawDigits = null;
        try( BufferedReader reader = new BufferedReader(new FileReader(fileName)) ) {
            String first_line = reader.readLine();
            int N = first_line.length();
            rawDigits = new int[N][N];

            for (int c = 0; c < first_line.length(); ++c) {
                rawDigits[0][c] = first_line.charAt(c);
            }

            String line;
            int col = 0;
            while ((line = reader.readLine()) != null) {
                for (int c = 0; c < line.length(); ++c) {
                    rawDigits[col][c] = Character.getNumericValue(line.charAt(c));
                }
                col++;
            }
            reader.close();
        }
        catch (IOException e) {
            System.exit(1);
        }

        // mindig inicializált a catch block miatt
        return rawDigits;
    }

    public int[][] getRaw() {return raw;}

    public void generate(List<Wall> walls, List<Box> boxes) throws IOException {
        int N = this.raw.length;
        for (int col = 0; col < N; ++col) {
            for (int row = 0; row < N; ++row) {
                switch (this.raw[col][row]) {
                    case 1:
                        walls.add(new Wall(col * BLOCK_SIZE, row * BLOCK_SIZE, BLOCK_SIZE));
                        break;
                    case 2:
                        boxes.add(new Box(col * BLOCK_SIZE, row * BLOCK_SIZE, BLOCK_SIZE));
                        break;
                    default:
                        // Ha az érték nem 1 vagy 2, nincs semmi teendő
                        break;
                }
            }
        }
    }
}
