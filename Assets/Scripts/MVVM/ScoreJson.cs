using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MVVM
{

    public class ScoreJson
    {
        private Score _score;
        public ScoreJson(Score score)
        {
            _score = score;
            
        }
        public static void SaveToJson(string path)
        {
            string json = JsonUtility.ToJson(path);
            File.WriteAllText(Application.dataPath + "Best score.json", json);
        }

        public static void LoadFromJson()
        {
            string path = Application.dataPath + "Best score.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(Application.dataPath + "Best score.json");
                Score score = JsonUtility.FromJson<Score>(json);
            }
            else
            {
                File.Create(path);
                LoadFromJson();
            }


        }

        //public static void IsTheBestScore(int fromOneApple)
        //{
        //    _currentScore += fromOneApple;

        //    if (_currentScore > bestScore)
        //    {
        //        bestScore = _currentScore;
        //        SaveToJson();
        //    }
        //}

    }
}
