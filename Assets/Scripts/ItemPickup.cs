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
        if (collision.CompareTag("Player"))
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
                StartCoroutine(FireDown(60f));
                break;

            case ItemType.BombUp:
                player.GetComponent<BombController>().bombCapacity++;
                break;

            case ItemType.NoBomb:
                StartCoroutine(NoBomb(20f));
                break;

            case ItemType.InstantPlace:
                StartCoroutine(InstantPlace(20f));
                break;

            case ItemType.SpeedDown:
                StartCoroutine(SpeedDown(40f));
                break;

        }

        Destroy(gameObject);

        IEnumerator FireDown(float duration)
        {
            int currentRadius = player.GetComponent<BombController>().expRadius;

            player.GetComponent<BombController>().expRadius = 1;

            yield return new WaitForSeconds(duration);

            player.GetComponent<BombController>().expRadius = currentRadius;

        }

        IEnumerator NoBomb(float duration)
        {
            player.GetComponent<BombController>().canPlace = false;

            yield return new WaitForSeconds(duration);

            player.GetComponent<BombController>().canPlace = true;
        }

        IEnumerator InstantPlace(float duration)
        {
            player.GetComponent<BombController>().instantPlace = true;

            yield return new WaitForSeconds(duration);

            player.GetComponent<BombController>().instantPlace = false;
        }

        IEnumerator SpeedDown(float duration)
        {
            float currentSpeed = player.GetComponent<MovementController>().speed;
            player.GetComponent<MovementController>().speed = 2.5f;

            yield return new WaitForSeconds(duration);

            player.GetComponent<MovementController>().speed = currentSpeed;
        }
    }
}
