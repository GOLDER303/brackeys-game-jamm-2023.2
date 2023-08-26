using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentWeaponController : WeaponController
{
    [SerializeField] protected GameObject weaponPrefab;
    [SerializeField] protected GameObject playerGameObject;

    protected override void Start()
    {
        base.Start();

        GameObject spawnedPersistentWeapon = Instantiate(weaponPrefab);

        spawnedPersistentWeapon.GetComponent<PersistentWeaponBehaviour>().followedObject = playerGameObject;
        spawnedPersistentWeapon.GetComponent<PersistentWeaponBehaviour>().Setup(weaponData.stagesSOs[currentUpgradeStage]);
    }
}
