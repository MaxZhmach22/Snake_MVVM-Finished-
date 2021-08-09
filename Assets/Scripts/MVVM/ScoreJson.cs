using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MVVM
{

    public class ScoreJson
    {
        private Score _score;
        public Action<int, int> OnScoreChanged;

        public Score Score { get => _score; set => _score = value; }

        public ScoreJson()
        {
            _score = new Score();
        }

        private void SaveToJson()
        {
            string json = JsonUtility.ToJson(_score);
            File.WriteAllText(Application.dataPath + "Best score.json", json);
        }

        public void ResetBestScore()
        {
            _score.bestScore = 0;
            SaveToJson();
            OnScoreChanged?.Invoke(_score.bestScore, _score._currentScore);
        }

        public void LoadFromJson()
        {
            string path = Application.dataPath + "Best score.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(Application.dataPath + "Best score.json");
                if (json == "") 
                {
                    json = JsonUtility.ToJson(_score);
                }
                _score = JsonUtility.FromJson<Score>(json);
                OnScoreChanged?.Invoke(_score.bestScore, _score._currentScore);
            }
            else
            {
                File.Create(path);
                LoadFromJson();
            }   
        }

        public void IsTheBestScore(int fromOneApple)
        {
            _score._currentScore += fromOneApple;

            if (_score._currentScore > _score.bestScore)
            {
                _score.bestScore = _score._currentScore;
                SaveToJson();
            }
            OnScoreChanged?.Invoke(_score.bestScore, _score._currentScore);
        }

    }
}
