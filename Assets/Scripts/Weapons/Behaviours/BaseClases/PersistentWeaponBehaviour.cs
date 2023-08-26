using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentWeaponBehaviour : WeaponBehaviour
{
    public GameObject followedObject { set; get; }

    [SerializeField] protected float speed;

    public override void Setup(UpgradeStageScriptableObject stageSO)
    {
        base.Setup(stageSO);
        speed = stageSO.speed;
    }
}
