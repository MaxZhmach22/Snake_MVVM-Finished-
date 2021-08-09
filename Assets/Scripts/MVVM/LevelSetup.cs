using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MVVM
{
    public sealed class LevelSetup
    {

        private int _weight;
        private int _height;
        private Sprite _backgroundImage;
        
        public int Weight => _weight; 
        public int Height => _height; 
        public LevelSetup(int weight, int height, GameData gameData)
        {
            _weight = weight;
            _height = height;
            _backgroundImage = gameData.BackgroundSprite;
            SetupBackgroundImage(_backgroundImage);
        }

        private void SetupBackgroundImage(Sprite backGroundSprite)
        {
            var gameObject = new GameObject("Background", typeof(SpriteRenderer));
            var background = gameObject.GetComponent<SpriteRenderer>();
            background.sprite = backGroundSprite;
            background.sortingLayerName = "Background";
            gameObject.transform.localScale = new Vector3(_height, _weight);
            gameObject.transform.position = new Vector3(_height / 2, _weight / 2);

        }
    }
}
