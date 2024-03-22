using System.Collections;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    // Reference to the bomb object in game
    public GameObject bombBlueprint;
    // Key code the player needs to press
    public KeyCode placeBombCode = KeyCode.Space;
    // Bombs time to live
    public float bombDuration = 3f;

    [Header("Explosion")]
    // Reference to the bomb object in game
    public Explosion expBlueprint;
    // Explosions time to live
    public float expDuration = 1f;
    // How many tiles does the explosion grow per tick
    public int expRadius = 1;
    public LayerMask expLayerMask;

    private void Update()
    {
        if (Input.GetKeyDown(placeBombCode))
        {
            StartCoroutine(PlaceBomb());
        }
    }

    private IEnumerator PlaceBomb()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(pos.y);

        GameObject bomb = Instantiate(bombBlueprint, pos, Quaternion.identity);

        yield return new WaitForSeconds(bombDuration);

        pos = bomb.transform.position;
        Explosion exp = Instantiate(expBlueprint, pos, Quaternion.identity);
        exp.SetActiveRenderer(exp.start);
        Destroy(exp.gameObject, expDuration);

        Explode(pos, Vector2.up, expRadius);
        Explode(pos, Vector2.down, expRadius);
        Explode(pos, Vector2.left, expRadius);
        Explode(pos, Vector2.right, expRadius);

        Destroy(bomb);
    }

    private void Explode(Vector2 position, Vector2 direction, int len)
    {
        if (len < 1)
        {
            return;
        }

        position += direction;
        // if the object at the next pos is a 'collider' (brick) then do nothing
        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, expLayerMask))
        {
            return;
        }

        Explosion exp = Instantiate(expBlueprint, position, Quaternion.identity);
        AnimatedSpriteRenderer renderer = len > 1 ? exp.middle : exp.end;
        exp.SetActiveRenderer(renderer);
        exp.SetDirection(direction);
        Destroy(exp.gameObject, expDuration);

        Explode(position, direction, len - 1);
    }
}
