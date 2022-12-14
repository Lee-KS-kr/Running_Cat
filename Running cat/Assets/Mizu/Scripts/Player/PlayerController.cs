using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 _inputVec = Vector3.zero;
        private Vector3 _dragVec = Vector3.zero;
        private float _turnAngle = 45f;
        private float _moveSpeed = 5f;
        private bool isStart = false;

        private PlayerCat[] cats;
        private TrackingCamera _cam;

        private void Start()
        {
            _cam = Camera.main.GetComponent<TrackingCamera>();
        }

        private void Update()
        {
            if (!isStart) return;
            GetCats();

            if (cats.Length < 1) return;
            SetCamPos();
            OnAutoMove();
            OnDrag();
        }

        private void GetCats()
        {
            cats = GetComponentsInChildren<PlayerCat>();
        }

        private void SetCamPos()
        {
            if (cats.Length == 1)
                _cam.SetPlayer(cats[0].transform.position);
            else
            {
                var pos = Vector3.zero;
                foreach (var cat in cats)
                    pos += cat.transform.position;

                pos = new Vector3(pos.x / cats.Length, pos.y/cats.Length, pos.z / cats.Length);
                _cam.SetPlayer(pos);
            }
        }

        private void OnAutoMove()
        {
            transform.position += transform.forward * Time.deltaTime * _moveSpeed;
            foreach (var cat in cats)
                cat.SetMoveAnim(true);
        }

        private void OnDrag()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _inputVec = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                _dragVec = Input.mousePosition;
                var dir = _dragVec.x - _inputVec.x;
                if (dir < 0f)
                {
                    foreach (var cat in cats)
                        cat.TurnAngle(-_turnAngle);

                    transform.position += -transform.right * Time.deltaTime * 10f;
                }
                else if (dir > 0f)
                {
                    foreach (var cat in cats)
                        cat.TurnAngle(_turnAngle);

                    transform.position += transform.right * Time.deltaTime * 10f;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                foreach (var cat in cats)
                    cat.ResetTurn();
            }
        }

        public void OnEndingScene()
        {
            _moveSpeed = 0f;
            foreach (var cat in cats)
                cat.SetAnimSpeed(4);
        }

        public void OnFinalCutscene()
        {
            foreach (var cat in cats)
                cat.SetMoveAnim(false);
        }

        public void OnStart()
        {
            isStart = true;
        }
    }
}