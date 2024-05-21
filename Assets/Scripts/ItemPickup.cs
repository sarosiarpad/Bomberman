using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public enum ItemType
    {
        FireUp,
        FireDown,
        BombUp,
        NoBomb,
        InstantPlace,
        SpeedDown
    }

    public ItemType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) ;
        {
            OnItemPickup(collision.gameObject);
        }
    }

    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.FireUp:
                player.GetComponent<BombController>().expRadius++;
                break;

            case ItemType.FireDown:
                StartCoroutine(FireDown(30f));
                break;

            case ItemType.BombUp:
                player.GetComponent<BombController>().bombCapacity++;
                break;

            case ItemType.NoBomb:
                StartCoroutine(NoBomb(30f));
                break;

            case ItemType.InstantPlace:
                StartCoroutine(InstantPlace(30f));
                break;

            case ItemType.SpeedDown:
                StartCoroutine(SpeedDown(30f));
                break;

        }

        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;


        IEnumerator FireDown(float duration)
        {
            int currentRadius = player.GetComponent<BombController>().expRadius;
            player.GetComponent<BombController>().expRadius = 1;
            yield return new WaitForSeconds(duration);
            player.GetComponent<BombController>().expRadius = currentRadius;
            Destroy(gameObject);

        }

        IEnumerator NoBomb(float duration)
        {
            player.GetComponent<BombController>().canPlace = false;
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
            player.GetComponent<BombController>().canPlace = true;
            Destroy(gameObject);
        }

        IEnumerator InstantPlace(float duration)
        {
            player.GetComponent<BombController>().instantPlace = true;
            yield return new WaitForSeconds(duration);
            player.GetComponent<BombController>().instantPlace = false;
            Destroy(gameObject);
        }

        IEnumerator SpeedDown(float duration)
        {
            float currentSpeed = player.GetComponent<MovementController>().speed;
            player.GetComponent<MovementController>().speed = 2.5f;
            yield return new WaitForSeconds(duration);
            player.GetComponent<MovementController>().speed = currentSpeed;
            Destroy(gameObject);
        }
    }
}
