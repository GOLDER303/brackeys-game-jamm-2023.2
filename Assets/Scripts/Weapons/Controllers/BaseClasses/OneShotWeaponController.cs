using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotWeaponController : WeaponController
{
    [SerializeField] protected GameObject weaponPrefab;
    [SerializeField] protected float cooldown;
    [SerializeField] protected PlayerMovement playerMovement;


    protected override void Start()
    {
        base.Start();
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(cooldown);
        }
    }

    protected override void Upgrade()
    {
        base.Upgrade();

        if (currentUpgradeStage < 0)
        {
            return;
        }

        if (!isEnabled)
        {
            StartCoroutine(AttackCoroutine());
            cooldown = weaponData.stagesSOs[currentUpgradeStage].cooldown;
            isEnabled = true;
        }
        else
        {
            if (currentUpgradeStage < maxUpgradeStage - 1)
            {
                cooldown = weaponData.stagesSOs[currentUpgradeStage].cooldown;
            }
        }
    }

    protected virtual void Attack() { }
}
