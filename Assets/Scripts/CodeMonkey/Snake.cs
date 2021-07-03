using CodeMonkey;
using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridPosition;
    private float gridMoveTime;
    private float gridMoveTimerMax = 1f;
    private Vector2Int gridMoveDirection = new Vector2Int(1, 0);
    private LevelGrid _levelGrid;
    private int snakeBodySize = 0;
    private List<Vector2Int> snakeMovePositonList = new List<Vector2Int>();

    public void Setup(LevelGrid levelGrid)
    {
        _levelGrid = levelGrid;
    }

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
    }
    private void Update()
    {

        HandInput();
        HandleGridMovemet();
    }


    private void HandInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != 1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != 1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
    }
    private void HandleGridMovemet()
    {
        gridMoveTime += Time.deltaTime;
        if (gridMoveTime >= gridMoveTimerMax)
        {
            gridMoveTime -= gridMoveTimerMax;

            snakeMovePositonList.Insert(0, gridPosition);

            gridPosition += gridMoveDirection;

            bool snakeAteFood = _levelGrid.TrySnakeEatFood(gridPosition);

            if (snakeAteFood)
            {
                snakeBodySize++;
            }

            if (snakeMovePositonList.Count >= snakeBodySize + 1)
            {
                snakeMovePositonList.RemoveAt(snakeMovePositonList.Count - 1);
            }

            for (int i = 0; i < snakeMovePositonList.Count; i++)
            {
                Vector2Int snakeMovePositon = snakeMovePositonList[i];
                World_Sprite worldSprite = World_Sprite.Create(new Vector3(snakeMovePositon.x, snakeMovePositon.y), Vector3.one * 0.5f, Color.white);
                FunctionTimer.Create(worldSprite.DestroySelf, gridMoveTimerMax);
            }
        }
        transform.position = new Vector3(gridPosition.x, gridPosition.y);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromDirection(gridMoveDirection) - 90);
       
    }

    private float GetAngleFromDirection(Vector2Int direction)
    {
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }
    public List<Vector2Int> GetFullSnakeGridPosition()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>();
        gridPositionList.AddRange(snakeMovePositonList);
        return gridPositionList;
    }
}
