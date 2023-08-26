using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : WeaponBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] protected float speed;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public override void Setup(UpgradeStageScriptableObject stageSO)
    {
        base.Setup(stageSO);
        speed = stageSO.speed;
    }
}
