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
        foreach (PersistentWeaponBehaviour spawnedWeapon in spawnedWeapons)
        {
            spawnedWeapon.Setup(weaponData.stagesSOs[currentUpgradeStage]);
        }

        for (int i = 0; i < weaponData.stagesSOs[currentUpgradeStage].count - spawnedWeapons.Count; i++)
        {
            SpawnWeapon();
        }

        base.Upgrade();
    }

    private void SpawnWeapon()
    {
        PersistentWeaponBehaviour spawnedPersistentWeapon = Instantiate(weaponPrefab);

        spawnedPersistentWeapon.GetComponent<PersistentWeaponBehaviour>().followedObject = playerGameObject;
        spawnedPersistentWeapon.GetComponent<PersistentWeaponBehaviour>().Setup(weaponData.stagesSOs[currentUpgradeStage]);

        spawnedWeapons.Add(spawnedPersistentWeapon);
    }
}
