using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class StageManager : MonoBehaviour
    {
        private Goal _goal;
        private Road _road;
        private TrackingCamera _cam;
        private PlayerController _controller;
        [SerializeField] private int _catCount = 0;
        public float Distance { get; private set; }
        private bool isGameStart = false;

        public void Initialize()
        {
            _goal = FindObjectOfType<Goal>();
            _cam = FindObjectOfType<TrackingCamera>();
            _controller = FindObjectOfType<PlayerController>();
            _road = FindObjectOfType<Road>();
            _goal.playerGoalAction = null;
            _goal.playerGoalAction += SetGoalIn;

            Distance = Vector3.Distance(_goal.transform.position, _controller.transform.position);
        }

        private void Update()
        {
            if (!isGameStart) return;
            Distance = Vector3.Distance(_goal.transform.position, _controller.transform.position);
        }

        private void SetGoalIn()
        {
            _cam.isEnding = true;
            _road.StartEnding(true);
            _controller.OnEndingScene();
            isGameStart = false;
            GameManager.Inst.UIMng.OnGoalIn();
        }

        public void StartGame()
        {
            _controller.OnStart();
            _catCount = 1;
            GameManager.Inst.SoundMng.PlaySFX(SoundManager.Sounds.Meow);
            isGameStart = true;
        }

        public void SetFinalCutscene()
        {
            _road.StartEnding(false);
            _controller.OnFinalCutscene();
            GameManager.Inst.UIMng.WinGame();
        }

        public void CountCat(int count)
        {
            _catCount += count;
            if (_catCount < 1)
                SetFailedGame();
        }

        private void SetFailedGame()
        {
            _controller.OnFailedGame();
            GameManager.Inst.UIMng.FailedGame();
        }
    }
}