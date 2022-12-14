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

        public void SetDistance(float goalPos)
        {
            _distance = goalPos;
        }

        private void Update()
        {
            if (!isStart) return;
            _now = Mathf.Clamp(_distance - GameManager.Inst.StageMng.Distance, 0f, 1f);
            _gage.fillAmount = _now;
        }
    }
}