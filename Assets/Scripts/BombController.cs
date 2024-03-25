using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    // Reference to the bomb object in game
    public GameObject bombBlueprint;
    // Key code the player needs to press
    public KeyCode placeBombCode = KeyCode.Space;
    // Bombs time to live
    public float bombDuration = 3f;
    // Max bomb capacity
    public int bombCapacity = 3;
    // Current bombs
    public int availableBombs = 3;
    // Reloading bomb
    public int reloadingBombs = 0;
    // Bomb restore time
    public float bombRestoreTime = 20f;
    // Can place bomb boolean (after placing bomb it turns false)
    public bool canPlace = true;
    // Bomb cooldown time
    public float bombCooldown = 3f;
    //InsantPlace is needed for the ItemPickups.cs
    public bool instantPlace = false;


    [Header("Explosion")]
    // Reference to the bomb object in game
    public Explosion expBlueprint;
    // Explosions time to live
    public float expDuration = 1f;
    // How many tiles does the explosion grow per tick
    public int expRadius = 2;
    public LayerMask expLayerMask;

    [Header("Destructible")]
    // Reference to a wall that's being destroyes
    public Tilemap destructibleTiles;
    public Destructible destructiblePrefab;

    private void Update()
    {
        if ((Input.GetKeyDown(placeBombCode) || instantPlace) && availableBombs > 0 && canPlace)
        {
            StartCoroutine(PlaceBomb());
            availableBombs--;
            canPlace = false;
            StartCoroutine(BombCooldown());
        }

        if(availableBombs + reloadingBombs < bombCapacity)
        {
            StartCoroutine(RestoreBombRoutine());
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
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(pos.y);

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
        if (len <= 0)
        {
            return;
        }

        position += direction;
        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, expLayerMask))
        {
            ClearDestructible(position);
            return;
        }

        Explosion exp = Instantiate(expBlueprint, position, Quaternion.identity);
        AnimatedSpriteRenderer renderer = len > 1 ? exp.middle : exp.end;
        exp.SetActiveRenderer(renderer);
        exp.SetDirection(direction);
        Destroy(exp.gameObject, expDuration);

        Explode(position, direction, len - 1);
    }

    private void ClearDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);

        if (tile != null)
        {
            Instantiate(destructiblePrefab, position, Quaternion.identity);
            destructibleTiles.SetTile(cell, null);
        }
    }

    private IEnumerator BombCooldown()
    {
        yield return new WaitForSeconds(bombCooldown);
        canPlace = true;
    }

    private IEnumerator RestoreBombRoutine()
    {
        reloadingBombs++;
        yield return new WaitForSeconds(bombRestoreTime);
        reloadingBombs--;
        availableBombs++;
    }
}
