using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float maxDepth;
    [SerializeField] private float topBorder;

    public float MaxDepth => maxDepth;
    public float TopBorder => topBorder;

    public void GameOver()
    {
        // TODO:
        Debug.Log("Game Over");
    }
}
