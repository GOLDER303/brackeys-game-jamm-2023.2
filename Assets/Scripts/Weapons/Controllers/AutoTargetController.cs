using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTargetController : OneShotWeaponController
{
    protected override void Attack()
    {
        base.Attack();

        GameObject spawnedAutoTarget = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        spawnedAutoTarget.GetComponent<AutoTargetBehaviour>().controllerGameObject = gameObject;
        spawnedAutoTarget.GetComponent<AutoTargetBehaviour>().Setup(weaponData.stagesSOs[currentUpgradeStage]);
    }
}
