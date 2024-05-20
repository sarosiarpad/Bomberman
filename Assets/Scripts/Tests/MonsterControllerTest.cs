using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MonsterControllerTest
{
    private GameObject monster;
    private MonsterController monsterController;

    [SetUp]
    public void SetUp()
    {
        // Setting up the monster and its components
        monster = new GameObject("Monster");
        monsterController = monster.AddComponent<MonsterController>();

        // Mock the AnimatedSpriteRenderers for the monster
        monsterController.upRenderer = new GameObject("UpRenderer").AddComponent<AnimatedSpriteRenderer>();
        monsterController.downRenderer = new GameObject("DownRenderer").AddComponent<AnimatedSpriteRenderer>();
        monsterController.leftRenderer = new GameObject("LeftRenderer").AddComponent<AnimatedSpriteRenderer>();
        monsterController.rightRenderer = new GameObject("RightRenderer").AddComponent<AnimatedSpriteRenderer>();
        monsterController.deathRenderer = new GameObject("DeathRenderer").AddComponent<AnimatedSpriteRenderer>();
        monsterController.hitRenderer = new GameObject("HitRenderer").AddComponent<AnimatedSpriteRenderer>();

        // Initialize default values
        monsterController.speed = 5f;
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.DestroyImmediate(monster);
    }

    [UnityTest]
    public IEnumerator TestMonsterMovement()
    {
        yield return null;

        Assert.AreNotEqual(Vector2.zero, monsterController.direction);
    }

    [UnityTest]
    public IEnumerator TestMonsterDeath()
    {
        // Call the Death method
        monsterController.Death();

        // Wait for a short time to allow death animation to play
        yield return null;

        // Check if monster is disabled and death renderer is enabled
        Assert.IsFalse(monsterController.enabled);
        Assert.IsTrue(monsterController.deathRenderer.enabled);
    }

    [UnityTest]
    public IEnumerator TestMonsterHit()
    {
        // Mock player
        GameObject player = new GameObject("Player");
        player.AddComponent<Rigidbody2D>();
        MovementController playerMovement = player.AddComponent<MovementController>();

        monsterController.Hit(player);
        yield return null;
        Assert.IsTrue(monsterController.hitRenderer);
        Assert.IsFalse(player.GetComponent<MovementController>().deathRenderer);
    }
}
