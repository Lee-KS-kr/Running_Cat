using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 _inputVec = Vector3.zero;
        private Vector3 _dragVec = Vector3.zero;
        private float turnAngle = 45f;

        private PlayerCat[] cats;

        private void Update()
        {
            GetCats();
            if (cats.Length < 1) return;
            OnAutoMove();
            OnDrag();
        }

        private void GetCats()
        {
            PlayerCat[] cats = GetComponentsInChildren<PlayerCat>();
        }

        private void OnAutoMove()
        {
            transform.position += transform.forward * Time.deltaTime * 5f;
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
                        cat.TurnAngle(-turnAngle);

                    transform.position += -transform.right * Time.deltaTime * 10f;
                }
                else if (dir > 0f)
                {
                    foreach (var cat in cats)
                        cat.TurnAngle(turnAngle);

                    transform.position += transform.right * Time.deltaTime * 10f;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                foreach (var cat in cats)
                    cat.TurnAngle();
            }
        }
    }
}