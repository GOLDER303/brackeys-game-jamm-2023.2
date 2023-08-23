using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTargetBehaviour : ProjectileWeaponBehaviour
{
    public GameObject controllerGameObject { set; private get; }

    private Queue<GameObject> targetQueue = new Queue<GameObject>();
    private HashSet<GameObject> targetsInRadius = new HashSet<GameObject>();
    private GameObject targetGameObject = null;
    private Vector3 heading = Vector3.zero;
    private bool hasHeading = false;

    private void Update()
    {
        if (hasHeading == false)
        {
            transform.position = controllerGameObject.transform.position;
        }

        while (targetQueue.Count > 0 && !targetsInRadius.Contains(targetGameObject))
        {
            targetGameObject = targetQueue.Dequeue();
        }

        if (targetGameObject != null)
        {
            heading = -(gameObject.transform.position - targetGameObject.transform.position).normalized;
            hasHeading = true;
        }

        transform.position += speed * Time.deltaTime * heading;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            targetQueue.Enqueue(other.gameObject);
            targetsInRadius.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (targetsInRadius.Contains(other.gameObject))
            {
                targetsInRadius.Remove(other.gameObject);
            }
        }
    }
}
