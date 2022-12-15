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
        private int hashRun = Animator.StringToHash("isRun");

        [SerializeField] private Material _mat;
        private Animator _animator;
        private Quaternion _before = Quaternion.Euler(0, 0, 0);
        private Quaternion _new = Quaternion.Euler(0, 0, 0);

        private void Start()
        {
            _playingLayer = LayerMask.NameToLayer("Playing");
            _strayLayer = LayerMask.NameToLayer("Stray");
            _catTowerLayer = LayerMask.NameToLayer("CatTower");

            _mat = Resources.Load<Material>("Otter/Arts/Materials/NewCat");
            _animator = gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _new, 3 * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == _strayLayer)
            {
                GameManager.Inst.StageMng.CountCat(1);
                var obj = collision.gameObject;
                obj.layer = gameObject.layer;
                obj.transform.parent = gameObject.transform.parent;
                obj.AddComponent<PlayerCat>();
                obj.GetComponent<Animator>().enabled = true;
                obj.GetComponentInChildren<Renderer>().material = _mat;
                GameManager.Inst.SoundMng.PlaySFX(SoundManager.Sounds.Meow);
            }

            if (collision.gameObject.layer == _catTowerLayer)
            {
                int jumpHeight = (int)collision.gameObject.GetComponent<CatTowerStep>().thisStep;
                OnJump(jumpHeight);
            }
        }

        private void OnDisable()
        {
            gameObject.layer = _playingLayer;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        private void OnJump(int height)
        {
            if (!this.enabled) return;
            _animator?.SetTrigger(hashJump);
            transform.position += Vector3.up * height;
        }

        public void SetMoveAnim(bool moving)
        {
            _animator.SetBool(hashMove, moving);
        }

        public void SetAnimSpeed(float speed)
        {
            _animator.speed = speed;
        }

        public void ChangeAnimClip()
        {
            _animator.SetBool(hashMove, false);
            _animator.SetBool(hashRun, true);
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