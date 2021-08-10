using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    public class ScoreJson
    {
        private Score _score;
        public Action<int, int> OnScoreChanged;
        private string _filePath; 
        public Score Score { get => _score; set => _score = value; }

        public ScoreJson()
        {
            _score = new Score();
            _filePath = GetPath();
        }

        private void SaveToJson()
        {
            string json = JsonUtility.ToJson(_score);
            File.WriteAllText(_filePath, json);
        }

        public void ResetBestScore()
        {
            _score.bestScore = 0;
            SaveToJson();
            OnScoreChanged?.Invoke(_score.bestScore, _score._currentScore);
        }

        public void LoadFromJson()
        {

            var jsonFile = Resources.Load<TextAsset>("Best Score");
            _score = JsonUtility.FromJson<Score>(jsonFile.ToString());
           
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
        public string GetPath()
        {
            string folderPath = (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer ? Application.persistentDataPath : Application.dataPath) + "/myDataFolder/";
            string filePath = folderPath + "Score.json";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                File.WriteAllText(filePath, JsonUtility.ToJson(_score));
            }
            else
            {
                string jsonText = File.ReadAllText(filePath);
                _score = JsonUtility.FromJson<Score>(jsonText);
            }
            return filePath;
        }

    }
}
