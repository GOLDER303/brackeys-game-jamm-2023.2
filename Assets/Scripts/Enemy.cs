using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    public GameObject targetGameObject { set; private get; }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetGameObject.transform.position, moveSpeed * Time.deltaTime);
    }
}
