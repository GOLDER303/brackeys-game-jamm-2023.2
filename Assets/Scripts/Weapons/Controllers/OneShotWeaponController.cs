using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotWeaponController : MonoBehaviour
{
    [SerializeField] protected GameObject weaponPrefab;
    [SerializeField] protected float cooldown;
    [SerializeField] protected PlayerMovement playerMovement;


    private void Start()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(cooldown);
        }
    }

    protected virtual void Attack() { }
}
