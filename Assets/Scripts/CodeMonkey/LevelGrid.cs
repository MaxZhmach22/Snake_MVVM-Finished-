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

        } while (_snake.GetFullSnakeGridPosition().IndexOf(foodGridPosition) !=-1);

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
            CMDebug.TextPopupMouse("Snake Ate Food");
            return true;
        }
        else
        {
            return false;
        }
    }
}
