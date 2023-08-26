
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricAuraController : OneShotWeaponController
{
    [SerializeField] float auraDuration = .5f;
    protected override void Attack()
    {
        base.Attack();

        GameObject spawnedAura = Instantiate(weaponPrefab, transform.position, Quaternion.identity, playerMovement.transform);
        spawnedAura.GetComponent<AuraBehaviour>().Setup(weaponData.stagesSOs[currentUpgradeStage]);

        Destroy(spawnedAura, auraDuration);
    }
}
