using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float maxDepth;

    public float MaxDepth => maxDepth;

    public void GameOver()
    {
        // TODO:
        Debug.Log("Game Over");
    }
}
