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
        private bool isEnding = false;

        [SerializeField] private PlayerCat[] cats;
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
            if (isEnding)
            {
                var pos = cats[0].transform.position;
                var str = cats[0].gameObject.name;

                for (int i = 0; i < cats.Length; i++)
                {
                    if (cats[i].transform.position.z <= pos.z)
                    {
                        pos = cats[i].transform.position;
                        str = cats[i].gameObject.name;
                    }
                }

                pos += new Vector3(0, 0, 2);
                _cam.SetPlayer(pos);
                return;
            }

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

        private void SetEndingCamPos()
        {

        }

        private void OnEndingMove()
        {
            GetCats();
            
        }

        private void OnAutoMove()
        {
            transform.position += transform.forward * Time.deltaTime * _moveSpeed;
            foreach (var cat in cats)
                cat.SetMoveAnim(true);
        }

        private void OnDrag()
        {
            if (_moveSpeed == 0f) return;

            if (Input.GetMouseButtonDown(0))
            {
                _inputVec = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                _dragVec = Input.mousePosition;
                var dir = _dragVec.x - _inputVec.x;
                float posX = cats[0].transform.position.x;
                if (dir < 0f)
                {
                    for(int i = 0; i < cats.Length; i++)
                    {
                        cats[i].TurnAngle(-_turnAngle);
                        if (cats[i].transform.position.x <= posX)
                            posX = cats[i].transform.position.x;
                    }

                    if (posX <= -6f) return;
                    transform.position += -transform.right * Time.deltaTime * (_moveSpeed * 2);
                }
                else if (dir > 0f)
                {
                    for (int i = 0; i < cats.Length; i++)
                    {
                        cats[i].TurnAngle(_turnAngle);
                        if (cats[i].transform.position.x >= posX)
                            posX = cats[i].transform.position.x;
                    }

                    if (posX >= 6f) return;
                    transform.position += transform.right * Time.deltaTime * (_moveSpeed * 2);
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
            isEnding = true;
            _moveSpeed = 0f;
            foreach (var cat in cats)
            {
                cat.SetAnimSpeed(2);
                cat.ChangeAnimClip();
            }
        }

        public void OnFinalCutscene()
        {
            GetCats();
            foreach (var cat in cats)
                cat.SetMoveAnim(false);
        }

        public void OnFailedGame()
        {
            isStart = false;
        }

        public void OnStart()
        {
            isStart = true;
        }
    }
}