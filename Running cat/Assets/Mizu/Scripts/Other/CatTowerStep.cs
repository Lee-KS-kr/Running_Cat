using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class CatTowerStep : MonoBehaviour
    {
        private int _playerLayer;
        private bool isCatSit = false;

        private ObstacleType _type = ObstacleType.CatTower;
        public Action<Animator, ObstacleType, Vector3> changeAnimAction;

        private void Start()
        {
            _playerLayer = LayerMask.NameToLayer("Player");
            isCatSit = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == _playerLayer)
            {
                if (isCatSit) return;

                var obj = collision.gameObject;
                isCatSit = true;
                this.enabled = false;
                obj.GetComponent<PlayerCat>().enabled = false;
                obj.transform.parent = gameObject.transform;
                obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                var anim = collision.gameObject.GetComponent<Animator>();
                changeAnimAction?.Invoke(anim, _type, gameObject.transform.position);
            }
        }
    }
}