using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float maxDepth;
    [SerializeField] private float topBorder;

    public float MaxDepth => maxDepth;
    public float TopBorder => topBorder;

    public void PlayAgain()
    {
        SceneManager.LoadScene("StartMenuScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void Win()
    {
        SceneManager.LoadScene("VictoryScene");
    }
}
