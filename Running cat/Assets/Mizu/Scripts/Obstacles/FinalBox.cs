using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class FinalBox : MonoBehaviour
    {
        private int _playerLayer;
        private int _winLayer;
        [SerializeField] private GameObject binBox;

        public ObstacleType _type = ObstacleType.FinalBox;
        public Action<Animator, ObstacleType, Vector3> changeAnimAction;

        private void Start()
        {
            _playerLayer = LayerMask.NameToLayer("Player");
            _winLayer = LayerMask.NameToLayer("Win");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == _playerLayer)
            {
                gameObject.GetComponent<Collider>().enabled = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Rigidbody>().useGravity = false;

                var obj = collision.gameObject;
                obj.GetComponent<PlayerCat>().enabled = false;
                obj.transform.position = transform.position;
                obj.transform.parent = this.transform;
                obj.transform.rotation = Quaternion.LookRotation(binBox.transform.position);
                obj.layer = _winLayer;
                var anim = obj.GetComponent<Animator>();

                changeAnimAction?.Invoke(anim, _type, gameObject.transform.position);
                this.enabled = false;
            }
        }
    }
}