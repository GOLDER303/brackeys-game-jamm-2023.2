using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingWeaponBehaviour : PersistentWeaponBehaviour
{
    [SerializeField] protected float radius;

    private void Update()
    {
        float angle = speed * Time.time;

        Vector3 newPosition = followedObject.transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

        transform.position = newPosition;
    }
}
