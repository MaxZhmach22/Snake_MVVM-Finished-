using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MVVM
{
    public static class SnakeFactory
    {
        public static Transform CreateGameObject(Sprite sprite)
        {
            var gameObject = new GameObject(sprite.name, typeof(SpriteRenderer));
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            return gameObject.transform;
        }
    }
}
