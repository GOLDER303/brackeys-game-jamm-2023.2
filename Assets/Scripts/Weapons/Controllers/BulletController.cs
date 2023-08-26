using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : OneShotWeaponController
{
    protected override void Attack()
    {
        base.Attack();

        GameObject spawnedBullet = Instantiate(weaponPrefab, transform.position, Quaternion.identity);

        float angle = Mathf.Atan2(playerMovement.facingDirection.y, playerMovement.facingDirection.x) * Mathf.Rad2Deg;
        spawnedBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        spawnedBullet.GetComponent<BulletBehaviour>().Direction = playerMovement.facingDirection;
        spawnedBullet.GetComponent<BulletBehaviour>().Setup(weaponData.stagesSOs[currentUpgradeStage]);
    }
}
