
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnemyEnterTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objectToBeDestroyed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (objectToBeDestroyed != null)
            {
                Destroy(objectToBeDestroyed);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
