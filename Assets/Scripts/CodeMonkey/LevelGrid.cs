using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class LevelGrid {
    private Vector2Int foodGridPosition;
    private int _width;
    private int _height;
    private GameObject foodGameObject;
    private Snake _snake;


    public void Setup (Snake snake)
    {
        _snake = snake;
        SpawnFood();
    }


    public LevelGrid(int width, int height)
    {
        _width = width;
        _height = height;

        
    }

    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, _width), Random.Range(0, _height));

        } while (_snake.GetFullSnakeGridPositionList().IndexOf(foodGridPosition) !=-1);

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if(snakeGridPosition == foodGridPosition)
        {
            GameObject.Destroy(foodGameObject);
            SpawnFood();
            GameHandler.AddScore();
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        if(gridPosition.x < 0)
        {
            gridPosition.x = _width - 1;
        }
        if (gridPosition.x > _width - 1)
        {
            gridPosition.x = 0;
        }
        if (gridPosition.y < 0)
        {
            gridPosition.y = _height - 1;
        }
        if (gridPosition.y > _height - 1)
        {
            gridPosition.y = 0;
        }
        return gridPosition;
    }
}
