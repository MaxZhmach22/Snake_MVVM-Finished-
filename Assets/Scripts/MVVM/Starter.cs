using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVM
{
    public class Starter : MonoBehaviour
    {
        
        void Start()
        {
            LevelSetup level = new LevelSetup(21, 21);
            SnakeModel snakeModel = new SnakeModel(1f);
            SnakeModelView snakeModelView = new SnakeModelView(snakeModel);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
