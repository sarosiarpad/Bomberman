import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Sprite;
import java.util.Random;

public class Box extends Sprite {
    private PowerUp powerup;
    private final int width = 100;
    private final int height = 100;
    private final Texture texture = "box.png";
    private int x;
    private int y;

    public Box(int x, int y) {
        super(texture, width, height);

        setPosition(x, y);

        PowerUp[] powerups = new PowerUp.values();
        Random random = new Random();
        powerup = powerups[random.nextInt(powerups.length)];
    }
    public PowerUp getPowerUp() {
        return powerUp;
    }
}
