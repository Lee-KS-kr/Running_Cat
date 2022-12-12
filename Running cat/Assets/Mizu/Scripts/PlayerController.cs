using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 _inputVec = Vector3.zero;
        private Vector3 _dragVec = Vector3.zero;

        private void Update()
        {
            OnAutoMove();
            OnDrag();
        }

        private void OnAutoMove()
        {
            PlayerCat[] cats = GetComponentsInChildren<PlayerCat>();
            if (cats.Length < 1) return;
            transform.position += transform.forward * Time.deltaTime * 5f;
        }

        private void OnDrag()
        {
            PlayerCat[] cats = GetComponentsInChildren<PlayerCat>();
            if (cats.Length < 1) return;

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
                        cat.TurnLeft();

                    transform.position += -transform.right * Time.deltaTime * 10f;
                }
                else if (dir > 0f)
                {
                    foreach (var cat in cats)
                        cat.TurnRight();

                    transform.position += transform.right * Time.deltaTime * 10f;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                foreach (var cat in cats)
                    cat.LookForward();
            }
        }
    }
}