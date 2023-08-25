using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private float maxDepth = 1000f;

    public float CurrentDepth => currentDepth;
    public float CurrentDepthPercentage => currentDepthPercentage;
    public float MaxDepth => maxDepth;

    private float currentDepth;
    private float currentDepthPercentage;

    private void Update()
    {
        currentDepth = -playerGameObject.transform.position.y;
        currentDepthPercentage = CurrentDepth / maxDepth;
    }
}
