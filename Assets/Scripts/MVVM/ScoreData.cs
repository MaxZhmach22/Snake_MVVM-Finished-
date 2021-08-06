using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MVVM
{
    [CreateAssetMenu(fileName = "StoreData", menuName = "Data", order = 1 )]
    public class ScoreData : ScriptableObject
    {
        private int _hightScore;
        private int _currentScore;
        private int _secondScore;
        private int _thirdScore;
        public List<int> _scoreList = new List<int>();

        
        public int HightScore { get => _hightScore; }
        public int CurrentScore { get => _currentScore; set => _currentScore = value; }
        public List<int> ScoreList { get => _scoreList; }

        private void CheckTheHighestScore()
        {
            if(_currentScore > _hightScore)
            {
                _hightScore = _currentScore;
                return;
            }
            else if(_currentScore> _secondScore)
            {
                _secondScore = _currentScore;
                return;
            }
            else if (_currentScore > _thirdScore)
            {
                _thirdScore = _currentScore;
                return;
            }
        }

        public void AddToScoreList()
        {
            CheckTheHighestScore();
            _scoreList.Add(_hightScore);
            _scoreList.Add(_secondScore);
            _scoreList.Add(_thirdScore);
            _scoreList.Sort();
            if (_scoreList.Count > 3)
            {
                _scoreList.RemoveAt(_scoreList.Count + 1);
            }
        }

        private void Awake()
        {
            _currentScore = 0;
            AddToScoreList();
        }


    }
}
