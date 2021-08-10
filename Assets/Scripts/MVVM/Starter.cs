using UnityEngine;

namespace MVVM
{
    public class Starter : MonoBehaviour
    {

        [SerializeField] private SnakeView _snakeView;
        [SerializeField] private FoodView  _foodView;
        [SerializeField] private InputView _inputView;
        [SerializeField] private UIView _uIView;

        private GameData _gameData;
        private SnakeModel _snakeModel;
        private SnakeModelView _snakeModelView;
        private UIModel _uiModel;
        private UIModelView _uiModelView;
        private AudioSource _audioSource;

        void Start()
        {
            _gameData = Resources.Load<GameData>("GameData");
            _gameData.IsMuted = false;
            ScoreJson _scoreJson = new ScoreJson();
            LevelSetup level = new LevelSetup(21, 21, _gameData);
            _snakeModel = new SnakeModel(1f, _gameData);
            _snakeModelView = new SnakeModelView(_snakeModel);
            _uiModel = new UIModel(_gameData);
            _uiModelView = new UIModelView(_uiModel, _scoreJson);
            _uIView.Initialize(_uiModelView, _gameData);
            _snakeView.Initialize(_snakeModelView, level, _gameData);
            _inputView.Initialize(_snakeModelView);
            _foodView.Initialize(_snakeModelView, level, _gameData);
            _snakeModelView.OnEatApple += _scoreJson.IsTheBestScore;
            _snakeView.OnSelfEating += _uiModelView.LooseGame;
            PlayBackgroundMusic();
            _gameData.OnMutedSound += StopBackgoundMusic;

        }

        private void PlayBackgroundMusic()
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
            _audioSource.clip = _gameData.BackGroundMusic;
            _audioSource.loop = true;
            
            if (!_gameData.IsMuted)
            {
                _audioSource.Play();
                
            }
        }
        private void StopBackgoundMusic(bool stop)
        {
            if (stop)
            {
                _audioSource.Stop();
            }
            else
            {
                _audioSource.Play();
            }
        }
    }

}
