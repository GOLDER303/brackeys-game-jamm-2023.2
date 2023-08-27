using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class ArtifactPointer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float hideDistance = 10f;

    private SpriteRenderer spriteRenderer;
    private Transform artifactTransform;

    private void OnEnable()
    {
        ArtifactManager.OnArtifactSpawn += HandleArtifactSpawn;
    }

    private void OnDisable()
    {
        ArtifactManager.OnArtifactSpawn -= HandleArtifactSpawn;
    }

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (artifactTransform == null)
        {
            return;
        }

        Vector3 directionToTarget = artifactTransform.position - playerTransform.position;

        if (directionToTarget.magnitude < hideDistance)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;

            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    private void HandleArtifactSpawn(Transform artifactTransform)
    {
        this.artifactTransform = artifactTransform;
        spriteRenderer.enabled = true;
    }
}
