using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class CatTowerStep : MonoBehaviour
    {
        private int _playerLayer;
        private ObstacleType _type = ObstacleType.CatTower;
        public Action<Animator, ObstacleType, Vector3> changeAnimAction;

        private void Start()
        {
            _playerLayer = LayerMask.NameToLayer("Player");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == _playerLayer)
            {
                collision.gameObject.GetComponent<PlayerCat>().enabled = false;
                var anim = collision.gameObject.GetComponent<Animator>();
                this.enabled = false;
                changeAnimAction?.Invoke(anim, _type, gameObject.transform.position);
            }
        }
    }
}