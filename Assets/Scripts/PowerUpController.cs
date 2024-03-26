using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public Dictionary<ItemPickup.ItemType, Coroutine> activePowerups = new Dictionary<ItemPickup.ItemType, Coroutine>();

    public void ApplyPowerup(ItemPickup.ItemType type, Coroutine coroutine)
    {
        if (activePowerups.ContainsKey(type))
        {
            StopCoroutine(activePowerups[type]);
            activePowerups.Remove(type);
        }

        activePowerups[type] = coroutine;
    }
}