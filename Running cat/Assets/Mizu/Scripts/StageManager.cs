using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class StageManager : MonoBehaviour
    {
        private Goal _goal;

        private void Start()
        {
            _goal = FindObjectOfType<Goal>();
            _goal.playerGoalAction = null;
            _goal.playerGoalAction += SetGoalIn;
        }

        private void SetGoalIn()
        {

        }
    }
}