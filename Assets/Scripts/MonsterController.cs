using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class MonsterController : MonoBehaviour
{
    public Rigidbody2D body { get; private set; }
    public float speed = 5f;
    private Vector2 direction = Vector2.down;

    public AnimatedSpriteRenderer upRenderer;
    public AnimatedSpriteRenderer downRenderer;
    public AnimatedSpriteRenderer leftRenderer;
    public AnimatedSpriteRenderer rightRenderer;
    public AnimatedSpriteRenderer deathRenderer;
    public AnimatedSpriteRenderer hitRenderer;
    private AnimatedSpriteRenderer activeRenderer;

    // For testing
    public bool immortal = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        activeRenderer = downRenderer;
    }

    private void Start()
    {
        StartCoroutine(SetDirectionCoroutine());
    }

    private IEnumerator SetDirectionCoroutine()
    {
        while (true)
        {
            System.Random rand = new System.Random();
            int rand_dir_num = rand.Next(0, 4);
            AnimatedSpriteRenderer newRenderer;

            switch (rand_dir_num)
            {
                case 0:
                    direction = Vector2.up;
                    newRenderer = upRenderer;
                    break;
                case 1:
                    direction = Vector2.down;
                    newRenderer = downRenderer;
                    break;
                case 2:
                    direction = Vector2.right;
                    newRenderer = rightRenderer;
                    break;
                case 3:
                    direction = Vector2.left;
                    newRenderer = leftRenderer;
                    break;
                default:
                    direction = Vector2.up;
                    newRenderer = upRenderer;
                    break;
            }

            upRenderer.enabled = newRenderer == upRenderer;
            downRenderer.enabled = newRenderer == downRenderer;
            leftRenderer.enabled = newRenderer == leftRenderer;
            rightRenderer.enabled = newRenderer == rightRenderer;

            activeRenderer = newRenderer;

            activeRenderer.isIdle = direction == Vector2.zero;

            yield return new WaitForSeconds(2f);
        }
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

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("palyer hit");
            Hit(collision.gameObject);
        }
    }

    private void Hit(GameObject player)
    {
        StopCoroutine(SetDirectionCoroutine());
        activeRenderer = hitRenderer;
        player.GetComponent<MovementController>().Death();
        StartCoroutine(SetDirectionCoroutine());
    }

    private void Death()
    {
        enabled = false;
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
    }
}
