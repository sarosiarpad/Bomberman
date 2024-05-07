using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AnimatedSpriteRenderer deathRenderer;
    private AnimatedSpriteRenderer activeRenderer;

    // For testing
    public bool immortal = false;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion") && !immortal)
        {
            Death();
        }
    }

    public void Death()
    {
        enabled = false;
        gameObject.GetComponent<BombController>().enabled = false;
        upRenderer.enabled = false;
        downRenderer.enabled = false;
        leftRenderer.enabled = false;
        rightRenderer.enabled = false;
        deathRenderer.enabled = true;

        Invoke(nameof(OnDeathEnded), 1.25f);
    }

    private void OnDeathEnded()
    {
        gameObject.SetActive(false);
        FindAnyObjectByType<GameOver>().Setup("uram");
        SceneManager.LoadScene("GameOver");
    }
}
