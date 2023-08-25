using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameManager gameManager;

    public float CurrentDepth => currentDepth;
    public float CurrentDepthPercentage => currentDepthPercentage;

    private float currentDepth;
    private float currentDepthPercentage;

    private void Update()
    {
        currentDepth = -playerGameObject.transform.position.y;
        currentDepthPercentage = CurrentDepth / gameManager.MaxDepth;
    }
}
