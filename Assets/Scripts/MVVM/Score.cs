using System;
using UnityEngine;

namespace MVVM
{
    [Serializable]
    public sealed class Score
    {
      public int bestScore = 0;
      [NonSerialized] public int _currentScore = 0;
    }
}
