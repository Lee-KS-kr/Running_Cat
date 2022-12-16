using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Mizu
{
    public class StageManager : MonoBehaviour
    {
        private Goal _goal;
        private Road _road;
        private TrackingCamera _cam;
        private PlayerController _controller;
        private FinalCutScene _finalCut;
        public FinalCutScene FinalCut => _finalCut;
        private PlayableDirector _director;

        [SerializeField] private int _catCount = 0;
        public float Distance { get; private set; }
        private bool isGameStart = false;

        public void Initialize()
        {
            _goal = FindObjectOfType<Goal>();
            _cam = FindObjectOfType<TrackingCamera>();
            _controller = FindObjectOfType<PlayerController>();
            _finalCut = FindObjectOfType<FinalCutScene>();
            _road = FindObjectOfType<Road>();
            _director = FindObjectOfType<PlayableDirector>();
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

            var cats = _controller.CatCount - 9;
            _finalCut?.SetBoxCount(cats);
            _finalCut?.gameObject.SetActive(true);
            GameManager.Inst.UIMng.OnGoalIn();
        }

        public void StartGame()
        {
            _controller.OnStart();
            _catCount = 1;
            GameManager.Inst.SoundMng.PlaySFX(SoundManager.Sounds.Meow);
            isGameStart = true;
            _finalCut.gameObject.SetActive(false);
        }

        public void SetFinalCutscene()
        {
            _road.StartEnding(false);
            _controller.OnFinalCutscene();
            _cam.SetFinal();
            //GameManager.Inst.UIMng.WinGame();
            _director.Play();
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