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
        instanceCount++;
        instanceIndex = instanceCount;
    }

    private void Update()
    {
        float angle = speed * Time.time + (((2 * Mathf.PI) / instanceCount) * instanceIndex);

        Vector3 newPosition = followedObject.transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;


        transform.position = newPosition;

    }
}
