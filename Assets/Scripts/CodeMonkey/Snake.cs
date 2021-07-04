using CodeMonkey;
using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }


    private enum State
    {
        Alive,
        Dead
    }

    private State state = State.Alive;
    private Vector2Int gridPosition;
    private float gridMoveTime;
    private float gridMoveTimerMax = 0.5f;
    private Direction gridMoveDirection = Direction.Right;
    private LevelGrid _levelGrid;
    private int snakeBodySize = 0;
    private List<SnakeMovePosition> snakeMovePositonList = new List<SnakeMovePosition>();
    private List<SnakeBodyPart> snakeBodyPartList = new List<SnakeBodyPart>();

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
        switch (state)
        {
            case State.Alive:

                HandInput();
                HandleGridMovemet();
                break;
            case State.Dead:
                break;
        }
    }


    private void HandInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection != Direction.Down)
            {
                gridMoveDirection = Direction.Up;
                
            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection != Direction.Up)
            {
                gridMoveDirection = Direction.Down;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection != Direction.Left)
            {
                gridMoveDirection = Direction.Right;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection != Direction.Right)
            {
                gridMoveDirection = Direction.Left;
            }
        }
    }
    private void HandleGridMovemet()
    {
        gridMoveTime += Time.deltaTime;
        if (gridMoveTime >= gridMoveTimerMax)
        {
            gridMoveTime -= gridMoveTimerMax;

            SnakeMovePosition previousSnakeMovePosition = null;
            if (snakeMovePositonList.Count > 0)
            {
                previousSnakeMovePosition = snakeMovePositonList[0];
            }

            SnakeMovePosition snakeMovePosition = new SnakeMovePosition(previousSnakeMovePosition, gridPosition, gridMoveDirection);
            snakeMovePositonList.Insert(0, snakeMovePosition);

            Vector2Int gridMoveDirectionVector;
            switch (gridMoveDirection)
            {
                default:
                case Direction.Right: gridMoveDirectionVector = new Vector2Int(+1, 0); break;
                case Direction.Left: gridMoveDirectionVector = new Vector2Int(-1, 0); break;
                case Direction.Up: gridMoveDirectionVector = new Vector2Int(0, +1); break;
                case Direction.Down: gridMoveDirectionVector = new Vector2Int(0, -1); break;
            }

            gridPosition += gridMoveDirectionVector;

            gridPosition = _levelGrid.ValidateGridPosition(gridPosition);

            bool snakeAteFood = _levelGrid.TrySnakeEatFood(gridPosition);

            if (snakeAteFood)
            {
                snakeBodySize++;
                CreateSnakeBodyPart();
            }

            if (snakeMovePositonList.Count >= snakeBodySize + 1)
            {
                snakeMovePositonList.RemoveAt(snakeMovePositonList.Count - 1);
            }

             UpdateSnakeBodyPart();
            foreach (SnakeBodyPart snakeBodyPart in snakeBodyPartList)
            {
                Vector2Int snakeBodyPartGridPosition = snakeBodyPart.GetGridPosition();
                if(gridPosition == snakeBodyPartGridPosition)
                {
                    Debug.Log("Dead");
                    state = State.Dead;
                    GameHandler.SnakeDied();
                }
            }

        transform.position = new Vector3(gridPosition.x, gridPosition.y);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromDirection(gridMoveDirectionVector) - 90);
           
        }
    }

    private float GetAngleFromDirection(Vector2Int direction) // +
    {
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    private void CreateSnakeBodyPart() //+
    {
        snakeBodyPartList.Add(new SnakeBodyPart(snakeBodyPartList.Count));
    }
   
    public List<Vector2Int> GetFullSnakeGridPositionList() //+
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>() {gridPosition};
        foreach (SnakeMovePosition snakeMovePosition in snakeMovePositonList)
        {
            gridPositionList.Add(snakeMovePosition.GetGridPosition());
        }
        return gridPositionList;
    }

    private void UpdateSnakeBodyPart() //+
    {
        for (int i = 0; i < snakeBodyPartList.Count; i++)
        {
            snakeBodyPartList[i].SetSnakeMovePosition(snakeMovePositonList[i]);
        }
    }

    private class SnakeBodyPart
    {
        private SnakeMovePosition snakeMovePosition;
        private Transform transform;
        
        public SnakeBodyPart(int bodyIndex)
        {
            GameObject snakeBodyGameObject = new GameObject("SnakeBody", typeof(SpriteRenderer));
            snakeBodyGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.snakeBodySprite;
            snakeBodyGameObject.GetComponent<SpriteRenderer>().sortingOrder = -bodyIndex;
            transform = snakeBodyGameObject.transform;
        }

        public void SetSnakeMovePosition(SnakeMovePosition snakeMovePosition) //+
        {
            this.snakeMovePosition = snakeMovePosition;
            transform.position = new Vector3(snakeMovePosition.GetGridPosition().x, snakeMovePosition.GetGridPosition().y);
            float angle;
            switch (snakeMovePosition.GetDirection())
            {
                default:
                case Direction.Up:
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default:
                            angle = 0; break;
                        case Direction.Left:
                            angle = 0 + 45; break;
                        case Direction.Right:
                            angle = 0 - 45;break;
                    }
                    break;

                case Direction.Down:
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default:
                            angle = 180; break;
                        case Direction.Left:
                            angle = 180 + 45; break;
                        case Direction.Right:
                            angle = 180 - 45; break;
                    }
                    break;
                   
                case Direction.Right:
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default:
                            angle = 90; break;
                        case Direction.Down:
                            angle = 45;break;
                        case Direction.Up:
                            angle = -45; break;
                    }
                    break;

                case Direction.Left:
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default:
                            angle = -90; break;
                        case Direction.Down:
                            angle = -45; break;
                        case Direction.Up:
                            angle = 45; break;
                    }
                    break;
            }
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        public Vector2Int GetGridPosition()
        {
            return snakeMovePosition.GetGridPosition();
        }
    }

    private class SnakeMovePosition
    {
        private SnakeMovePosition previousSnakeMovePositon;
        private Vector2Int gridPosition;
        private Direction direction;

        public SnakeMovePosition(SnakeMovePosition previousSnakeMovePositon, Vector2Int gridPosition, Direction direction)
        {
            this.previousSnakeMovePositon = previousSnakeMovePositon;
            this.gridPosition = gridPosition;
            this.direction = direction;
        }

        public Vector2Int GetGridPosition() //+
        {
            return gridPosition;
        }

        public Direction GetDirection() //+
        {
            return direction;
        }

        public Direction GetPreviousDirection() //+
        {
            if (previousSnakeMovePositon == null)
            {
                return Direction.Right;
            }else
            return previousSnakeMovePositon.direction;
        }
    }
}
