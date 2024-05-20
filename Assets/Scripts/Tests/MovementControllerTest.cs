using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementControllerTest
{
    private GameObject player;
    private MovementController playerMovement;
    private BombController bombController;
    private Rigidbody2D playerRigidbody;

    [SetUp]
    public void SetUp()
    {
        // Setting up the player and its components
        player = new GameObject("Player");
        playerRigidbody = player.AddComponent<Rigidbody2D>();
        playerMovement = player.AddComponent<MovementController>();
        bombController = player.AddComponent<BombController>();
        playerMovement.body = playerRigidbody;

        // Mock the AnimatedSpriteRenderers for the player
        playerMovement.upRenderer = new GameObject("UpRenderer").AddComponent<AnimatedSpriteRenderer>();
        playerMovement.downRenderer = new GameObject("DownRenderer").AddComponent<AnimatedSpriteRenderer>();
        playerMovement.leftRenderer = new GameObject("LeftRenderer").AddComponent<AnimatedSpriteRenderer>();
        playerMovement.rightRenderer = new GameObject("RightRenderer").AddComponent<AnimatedSpriteRenderer>();
        playerMovement.deathRenderer = new GameObject("DeathRenderer").AddComponent<AnimatedSpriteRenderer>();

        // Mock the GameController for the player
        playerMovement.gameController = new GameObject("GameController").AddComponent<GameController>();
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test using DestroyImmediate
        Object.DestroyImmediate(player);
    }

    // Test to ensure initial setup is correct
    [Test]
    public void InitialSetupTest()
    {
        Assert.NotNull(playerMovement.body);
        Assert.AreEqual(playerMovement.speed, 5f);
        Assert.AreEqual(playerMovement.direction, Vector2.down);
        Assert.NotNull(playerMovement.upRenderer);
        Assert.NotNull(playerMovement.downRenderer);
        Assert.NotNull(playerMovement.leftRenderer);
        Assert.NotNull(playerMovement.rightRenderer);
        Assert.NotNull(playerMovement.deathRenderer);
        Assert.NotNull(playerMovement.gameController);
    }

    // Test player movement upwards
    [UnityTest]
    public IEnumerator TestPlayerMovementUp()
    {
        // Simulate pressing the UP key
        playerMovement.SetDirection(Vector2.up, playerMovement.upRenderer);
        yield return null;

        // Assert the direction and renderer
        Assert.AreEqual(Vector2.up, playerMovement.direction);
        Assert.IsTrue(playerMovement.upRenderer.enabled);
        Assert.IsFalse(playerMovement.downRenderer.enabled);
        Assert.IsFalse(playerMovement.leftRenderer.enabled);
        Assert.IsFalse(playerMovement.rightRenderer.enabled);
    }

    // Test player death upon collision with explosion
    [UnityTest]
    public IEnumerator TestPlayerDeath()
    {
        // Simulate collision with explosion
        GameObject explosion = new GameObject("Explosion");
        explosion.layer = LayerMask.NameToLayer("Explosion");
        Collider2D playerCollider = player.AddComponent<BoxCollider2D>();
        Collider2D explosionCollider = explosion.AddComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, explosionCollider, false);

        explosion.transform.position = player.transform.position;
        yield return null;

        playerMovement.OnTriggerEnter2D(explosionCollider);
        yield return null;

        Assert.IsFalse(playerMovement.enabled);
        Assert.IsTrue(playerMovement.deathRenderer.enabled);
        Assert.IsFalse(playerMovement.upRenderer.enabled);
        Assert.IsFalse(playerMovement.downRenderer.enabled);
        Assert.IsFalse(playerMovement.leftRenderer.enabled);
        Assert.IsFalse(playerMovement.rightRenderer.enabled);
    }
}
