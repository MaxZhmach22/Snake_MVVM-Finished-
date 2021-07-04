using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GameAssets : MonoBehaviour
{
    public static GameAssets i;

    private void Awake()
    {
        i = this;
    }

    public Sprite snakeHeadSprite;
    public Sprite foodSprite;
    public Sprite snakeBodySprite;
}

