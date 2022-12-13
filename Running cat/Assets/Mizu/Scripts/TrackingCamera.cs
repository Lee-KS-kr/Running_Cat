using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class TrackingCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 _player;
        [SerializeField] private Vector3 _offset = new Vector3(0, 6.2f, -5f);
        [SerializeField] private Vector3 _afterGoalPos = new Vector3(10.5938f, 6.2f, 2.02954f);
        private Quaternion _afterGoalRot = Quaternion.Euler(0, -90f, 0f);

        public bool isEnding = false;

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>().transform.position;
        }

        private void Update()
        {
            if(isEnding)
                SetEndingCamera();
        }

        private void LateUpdate()
        {
            transform.position = _player + _offset;
        }

        private void SetEndingCamera()
        {
            _offset = Vector3.Slerp(_offset, _afterGoalPos, 5 * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, _afterGoalRot, 5 * Time.deltaTime);
        }

        public void SetPlayer(Vector3 pos)
        {
            _player = pos;
        }
    }
}