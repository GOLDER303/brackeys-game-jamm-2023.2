using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : OneShotWeaponController
{
    protected override void Attack()
    {
        base.Attack();

        GameObject spawnedBullet = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        spawnedBullet.GetComponent<BulletBehaviour>().Direction = playerMovement.facingDirection;
    }
}
