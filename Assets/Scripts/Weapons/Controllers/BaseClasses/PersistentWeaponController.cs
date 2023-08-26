using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentWeaponController : WeaponController
{
    [SerializeField] protected PersistentWeaponBehaviour weaponPrefab;
    [SerializeField] protected GameObject playerGameObject;

    private readonly List<PersistentWeaponBehaviour> spawnedWeapons = new();

    protected override void Start()
    {
        base.Start();
    }

    protected override void Upgrade()
    {
        base.Upgrade();

        if (currentUpgradeStage < 0)
        {
            return;
        }

        foreach (PersistentWeaponBehaviour spawnedWeapon in spawnedWeapons)
        {
            spawnedWeapon.Setup(weaponData.stagesSOs[currentUpgradeStage]);
        }

        while (spawnedWeapons.Count < weaponData.stagesSOs[currentUpgradeStage].count)
        {
            SpawnWeapon();
        }
    }

    private void SpawnWeapon()
    {
        PersistentWeaponBehaviour spawnedPersistentWeapon = Instantiate(weaponPrefab);

        spawnedPersistentWeapon.GetComponent<PersistentWeaponBehaviour>().followedObject = playerGameObject;
        spawnedPersistentWeapon.GetComponent<PersistentWeaponBehaviour>().Setup(weaponData.stagesSOs[currentUpgradeStage]);

        spawnedWeapons.Add(spawnedPersistentWeapon);
    }
}
