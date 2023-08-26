using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingWeaponBehaviour : PersistentWeaponBehaviour
{
    private static int instanceCount = 0;

    [SerializeField] protected float radius;

    private readonly int instanceIndex;

    public CirclingWeaponBehaviour()
    {
        instanceIndex = instanceCount;
        instanceCount++;
    }

    private void Update()
    {
        float angle = speed * Time.time + instanceIndex * (360f / instanceCount);

        Vector3 newPosition = followedObject.transform.position + Quaternion.Euler(0, 0, angle) * (Vector3.right * radius);

        transform.position = newPosition;
    }
}
