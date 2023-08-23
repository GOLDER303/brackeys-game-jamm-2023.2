using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentWeaponController : MonoBehaviour
{
    [SerializeField] protected GameObject weaponPrefab;
    [SerializeField] protected GameObject playerGameObject;

    private void Start()
    {
        GameObject spawnedPersistentWeapon = Instantiate(weaponPrefab);

        spawnedPersistentWeapon.GetComponent<PersistentWeaponBehaviour>().followedObject = playerGameObject;
    }
}
