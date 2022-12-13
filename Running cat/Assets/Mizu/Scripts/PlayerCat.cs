using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class PlayerCat : MonoBehaviour
    {
        private int _strayLayer = 0;
        private int _playingLayer = 0;
        private int _catTowerLayer = 0;

        private int hashMove = Animator.StringToHash("isMove");
        private int hashJump = Animator.StringToHash("onJump");
        private bool isJump = false;

        [SerializeField] private Material _mat;
        private Animator _animator;
        private Rigidbody _rigidbody;
        private Quaternion _before = Quaternion.Euler(0, 0, 0);
        private Quaternion _new = Quaternion.Euler(0, 0, 0);
        private Vector3 _newPos = Vector3.zero;

        private void Start()
        {
            _playingLayer = LayerMask.NameToLayer("Playing");
            _strayLayer = LayerMask.NameToLayer("Stray");
            _catTowerLayer = LayerMask.NameToLayer("CatTower");
            _mat = Resources.Load<Material>("Otter/Arts/Texture/NewCat");
            _rigidbody = gameObject.GetComponent<Rigidbody>();
            _animator = gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _new, 3 * Time.deltaTime);
            //if (!isJump) return;
            //OnJump();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == _strayLayer)
            {
                var obj = collision.gameObject;
                obj.layer = gameObject.layer;
                obj.transform.parent = gameObject.transform.parent;
                obj.AddComponent<PlayerCat>();
                obj.GetComponent<Animator>().enabled = true;
                obj.GetComponentInChildren<Renderer>().material = _mat;
            }

            if(collision.gameObject.layer == _catTowerLayer)
            {
                //isJump = false;
                //_newPos = transform.position + new Vector3(0, 5f, 0);
                //isJump = true;
                //_animator.SetTrigger(hashJump);
                OnJump();
            }
        }

        private void OnDisable()
        {
            gameObject.layer = _playingLayer;
            gameObject.transform.parent = null;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }

        private void OnJump()
        {
            //transform.position = Vector3.Lerp(transform.position, _newPos, 3f * Time.deltaTime);
            //if (Vector3.SqrMagnitude(transform.position - _newPos) < 0.1f)
            //    isJump = false;

            _animator.SetTrigger(hashJump);
            transform.position += Vector3.up * 4;
        }

        public void SetMoveAnim(bool moving)
        {
            _animator.SetBool(hashMove, moving);
        }

        public void SetAnimSpeed(float speed)
        {
            _animator.speed = speed;
        }

        public void TurnAngle(float yAngle = 0)
        {
            _before = transform.rotation;
            _new = Quaternion.Euler(0, yAngle, 0);
        }

        public void ResetTurn()
        {
            _before = Quaternion.Euler(0, 0, 0);
            _new = _before;
        }
    }
}