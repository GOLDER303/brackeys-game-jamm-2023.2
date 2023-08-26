
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnEnemyEnterTrigger : MonoBehaviour
{
    [SerializeField] private WeaponBehaviour weaponBehaviour;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().DealDamage(weaponBehaviour.Damage);
        }
    }
}
