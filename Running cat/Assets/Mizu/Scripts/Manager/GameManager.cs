using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mizu
{
    public sealed class GameManager
    {
        private static GameManager instance;
        public static GameManager Inst
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }

        public GameManager()
        {
            if (instance != null) return;

            Initialize();
        }

        private SoundManager _soundManager;
        private UIManager _uiManager;
        private ObstacleManager _obstacleManager;
        private StageManager _stageManager;
        private GameObject _manager;

        public SoundManager SoundMng => _soundManager;
        public UIManager UIMng => _uiManager;
        public ObstacleManager ObstacleMnr => _obstacleManager;
        public StageManager StageMng => _stageManager;
        
        private void Initialize()
        {
            _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
            _obstacleManager = GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>();
            _stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
            _manager = GameObject.Find("Managers");
            GameObject.DontDestroyOnLoad(_manager);
        }

        public void StartGame()
        {
            _uiManager.StartGame();
            _stageManager.StartGame();
            _soundManager.StartGame();
        }

        public void RestartGame()
        {
            _soundManager.OnRestart();
            _obstacleManager.OnRestart();
            SceneManager.LoadScene(0);
        }
    }
}