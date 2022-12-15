using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mizu
{
    public class GageUI : MonoBehaviour
    {
        [SerializeField] private Image _gage;
        private float _distance = 0f;
        private float _now = 0f;
        public bool isStart = false;

        private void Start()
        {
            _gage.fillAmount = 0f;
        }

        public void SetGoal(float goalDis)
        {
            _distance = goalDis;
        }

        public void SetDistance(float nowDis)
        {
            _now = Mathf.Clamp(1 - (nowDis / _distance), 0f, 1f);
        }

        private void Update()
        {
            if (!isStart) return;

            _gage.fillAmount = _now;
        }
    }
}