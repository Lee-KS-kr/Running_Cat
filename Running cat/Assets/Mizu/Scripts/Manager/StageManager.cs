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

        private void Start()
        {
            _goal = FindObjectOfType<Goal>();
            _cam = FindObjectOfType<TrackingCamera>();
            _controller = FindObjectOfType<PlayerController>();
            _road = FindObjectOfType<Road>();
            _goal.playerGoalAction = null;
            _goal.playerGoalAction += SetGoalIn;
        }

        private void SetGoalIn()
        {
            _cam.isEnding = true;
            _road.StartEnding();
            _controller.OnEndingScene();
        }

        public void StartGame()
        {
            Debug.Log("to do : StageManager startGame");
        }
    }
}