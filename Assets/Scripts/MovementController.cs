using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D body { get; private set; }
    public float speed = 5f;
    private Vector2 direction = Vector2.down;
    public KeyCode UP = KeyCode.W;
    public KeyCode LEFT = KeyCode.A;
    public KeyCode DOWN = KeyCode.S;
    public KeyCode RIGHT = KeyCode.D;

    public AnimatedSpriteRenderer upRenderer;
    public AnimatedSpriteRenderer downRenderer;
    public AnimatedSpriteRenderer leftRenderer;
    public AnimatedSpriteRenderer rightRenderer;
    private AnimatedSpriteRenderer activeRenderer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        activeRenderer = downRenderer;
    }

    private void Update() 
    {
        if (Input.GetKey(UP)) {
            SetDirection(Vector2.up, upRenderer);
        } else if (Input.GetKey(DOWN)) {
            SetDirection(Vector2.down, downRenderer);
        } else if (Input.GetKey(LEFT)) {
            SetDirection(Vector2.left, leftRenderer);
        } else if (Input.GetKey(RIGHT)) {
            SetDirection(Vector2.right, rightRenderer);
        } else {
            SetDirection(Vector2.zero, activeRenderer);
        }

    }

    private void SetDirection(Vector2 newDir, AnimatedSpriteRenderer newRenderer)
    {
        direction = newDir;

        upRenderer.enabled = newRenderer == upRenderer;
        downRenderer.enabled = newRenderer == downRenderer;
        leftRenderer.enabled = newRenderer == leftRenderer;
        rightRenderer.enabled = newRenderer == rightRenderer;

        activeRenderer = newRenderer;

        activeRenderer.isIdle = newDir == Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector2 pos = body.position;
        Vector2 translation = speed * Time.fixedDeltaTime * direction;

        body.MovePosition(pos + translation);
    }
}
