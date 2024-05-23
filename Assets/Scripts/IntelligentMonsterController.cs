using System.Collections;
using UnityEngine;
using Pathfinding;

// IntelligentMonsterController handles the behavior of an intelligent monster in the game
public class IntelligentMonsterController : MonoBehaviour
{
    // Reference to the GameController
    public GameController gameController;

    // Reference to the monster's Rigidbody2D component
    public Rigidbody2D Body { get; private set; }

    // References to animated sprite renderers for different directions
    public AnimatedSpriteRenderer upRenderer;
    public AnimatedSpriteRenderer downRenderer;
    public AnimatedSpriteRenderer leftRenderer;
    public AnimatedSpriteRenderer rightRenderer;

    // Additional sprite renderers for death and hit animations
    public AnimatedSpriteRenderer deathRenderer;
    public AnimatedSpriteRenderer hitRenderer;

    public AnimatedSpriteRenderer activeRenderer;

    [Header("Pathfinding")]
    public float maxSpeed = 3f;
    public float delay = 5f; // default
    private Seeker seeker;
    private AIPath aiPath;
    private AIDestinationSetter destinationSetter;

    // Coroutine to update monster's destination
    void OnEnable()
    {
        StartCoroutine(UpdateDestinationCoroutine());
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize pathfinding components
        seeker = GetComponent<Seeker>();
        aiPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();

        if (!seeker)
        {
            Debug.LogWarning("Seeker component not found");
        }

        if (!aiPath)
        {
            Debug.LogWarning("AIPath component not found");
        }
        else
        {
            aiPath.maxSpeed = maxSpeed;
        }

        if (!destinationSetter)
        {
            Debug.LogWarning("AIDestinationSetter component not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set active sprite renderer based on the next move the monster will take
        activeRenderer = GetSpriteRendererPerDirection(aiPath.desiredVelocity);

        upRenderer.enabled = activeRenderer == upRenderer;
        downRenderer.enabled = activeRenderer == downRenderer;
        leftRenderer.enabled = activeRenderer == leftRenderer;
        rightRenderer.enabled = activeRenderer == rightRenderer;
    }

    // Coroutine to update monster's destination
    IEnumerator UpdateDestinationCoroutine()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            var closestPlayer = FindClosestPlayer();
            if (closestPlayer != null)
            {
                if (closestPlayer != destinationSetter.target)
                {
                    destinationSetter.target = closestPlayer;
                    Debug.Log("New target: " + closestPlayer.name);
                }
            }
            else
            {
                Debug.LogWarning("No target found :(");
            }

            yield return new WaitForSeconds(delay);
        }
    }

    // Find the closest player to the monster
    Transform FindClosestPlayer()
    {
        float minDist = Mathf.Infinity;
        Transform closest = null;

        foreach (GameObject p in gameController.playerSet)
        {
            if (!p.activeSelf)
            {
                continue;
            }

            float dist = Vector3.Distance(transform.position, p.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = p.transform;
            }
        }

        return closest;
    }

    // Handle collisions with other game objects
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // If collided with an explosion, trigger death animation
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            Death();
        }

        // If collided with a player, trigger hit animation
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StartCoroutine(Hit(collision.gameObject));
        }
    }

    // Coroutine to handle hit animation and player death
    private IEnumerator Hit(GameObject player)
    {
        // Stop movement and trigger hit animation
        upRenderer.enabled = false;
        downRenderer.enabled = false;
        leftRenderer.enabled = false;
        rightRenderer.enabled = false;
        hitRenderer.enabled = true;
        player.GetComponent<MovementController>().Death();

        // Resume movement after a delay
        yield return new WaitForSeconds(1f);
        hitRenderer.enabled = false;
    }

    // Handle monster's death
    private void Death()
    {
        enabled = false;

        // Disable movement and trigger death animation
        upRenderer.enabled = false;
        downRenderer.enabled = false;
        leftRenderer.enabled = false;
        rightRenderer.enabled = false;
        deathRenderer.enabled = true;

        // Deactivate monster object after death animation
        Invoke(nameof(OnDeathEnded), 1.25f);
    }

    // Callback method after death animation ends
    private void OnDeathEnded()
    {
        gameObject.SetActive(false);
    }

    // Get the sprite renderer based on the monster's movement direction
    private AnimatedSpriteRenderer GetSpriteRendererPerDirection(Vector2 direction)
    {
        var dir = direction.normalized;

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
            {
                return this.rightRenderer;
            }
            else if (dir.x < 0)
            {
                return this.leftRenderer;
            }
        }
        else
        {
            if (dir.y > 0)
            {
                return this.upRenderer;
            }
            else if (dir.y < 0)
            {
                return this.upRenderer;
            }
        }


        return this.leftRenderer; // default
    }
}