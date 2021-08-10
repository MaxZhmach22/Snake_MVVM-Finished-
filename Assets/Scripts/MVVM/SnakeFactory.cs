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
