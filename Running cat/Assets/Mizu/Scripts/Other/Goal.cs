using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class Goal : MonoBehaviour
    {
        private int _playerLayer;
        public Action playerGoalAction;

        private void Start()
        {
            _playerLayer = LayerMask.NameToLayer("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == _playerLayer)
            {
                this.enabled = false;
                playerGoalAction?.Invoke();
            }
        }
    }
}