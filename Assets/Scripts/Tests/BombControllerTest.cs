using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Tilemaps;

public class BombControllerTest
{
    private GameObject player;
    private BombController bombController;
    private GameObject bombBlueprint;
    private Explosion expBlueprint;
    private Tilemap destructibleTiles;

    [SetUp]
    public void SetUp()
    {
        // Setting up the player and its components
        player = new GameObject("Player");
        bombController = player.AddComponent<BombController>();

        // Mock the bomb blueprint
        bombBlueprint = new GameObject("BombBlueprint");
        bombController.bombBlueprint = bombBlueprint;

        // Mock the explosion blueprint
        expBlueprint = new GameObject("ExplosionBlueprint").AddComponent<Explosion>();
        bombController.expBlueprint = expBlueprint;

        // Mock the destructible tiles
        destructibleTiles = new GameObject("DestructibleTiles").AddComponent<Tilemap>();
        bombController.destructibleTiles = destructibleTiles;

        // Initialize default values
        bombController.bombDuration = 1f;
        bombController.expDuration = 1f;
        bombController.expRadius = 2;
        bombController.bombCapacity = 3;
        bombController.availableBombs = 3;
        bombController.bombCooldown = 0.5f;
        bombController.bombRestoreTime = 1f;
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.DestroyImmediate(player);
        Object.DestroyImmediate(bombBlueprint);
        Object.DestroyImmediate(expBlueprint.gameObject);
        Object.DestroyImmediate(destructibleTiles.gameObject);
    }

    [UnityTest]
    public IEnumerator TestBombCooldown()
    {
        bombController.PlaceBomb();
        yield return null;
        Assert.AreEqual(bombController.availableBombs, 2);
        Assert.IsFalse(bombController.canPlace);


    }
}
