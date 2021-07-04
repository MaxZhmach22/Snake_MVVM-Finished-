

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    private LevelGrid levelGrid;
    private static int score;
    private static GameHandler instance;
    [SerializeField] private Snake snake;

    private void Awake()
    {
        instance = this;
        InitializeStatic();
    }

    private void Start()
    {
        levelGrid = new LevelGrid(21, 21);
        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
    }

    private static void InitializeStatic()
    {
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 100;
    }

    public static void SnakeDied()
    {
        GameOverWindow.ShowStatic();
    }
    


}
