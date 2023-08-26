using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] protected float damage;

    public float Damage => damage;

    public virtual void Setup(UpgradeStageScriptableObject stageSO)
    {
        damage = stageSO.damage;
    }
}
