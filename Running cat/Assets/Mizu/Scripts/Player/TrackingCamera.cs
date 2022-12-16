using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class TrackingCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 _player;
        private Vector3 _offset = new Vector3(0, 6.2f, -5f);
        private Vector3 _afterGoalPos = new Vector3(10.5938f, 3f, 2.02954f);
        private Vector3 _finalOffset = new Vector3(0, 28f, 74f);
        private Quaternion _afterGoalRot = Quaternion.Euler(0, -90f, 0f);

        public bool isEnding = false;
        public bool isFinal = false;

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>().transform.position;
        }

        private void Update()
        {
            if(isEnding)
                SetEndingCamera();

            if (isFinal)
                SetFinalCutscene();
        }

        private void LateUpdate()
        {
            if (isFinal) return;
            transform.position = _player + _offset;
        }

        private void SetEndingCamera()
        {
            _offset = Vector3.Slerp(_offset, _afterGoalPos, 5 * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, _afterGoalRot, 5 * Time.deltaTime);
        }

        private void SetFinalCutscene()
        {
            transform.position = Vector3.Slerp(transform.position, _finalOffset, 1 * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 1 * Time.deltaTime);
        }

        public void SetFinal()
        {
            isEnding = false;
            isFinal = true;
        }

        public void SetPlayer(Vector3 pos)
        {
            _player = pos;
        }
    }
}