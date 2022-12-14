using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class CatTowerStep : MonoBehaviour
    {
        private int _playerLayer;
        [SerializeField] private bool isCatSit;

        private ObstacleType _type = ObstacleType.CatTower;
        public Action<Animator, ObstacleType, Vector3> changeAnimAction;

        private void Start()
        {
            _playerLayer = LayerMask.NameToLayer("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _playerLayer)
            {
                if (isCatSit) return;

                var obj = other.gameObject;
                isCatSit = true;
                this.enabled = false;
                obj.GetComponent<PlayerCat>().enabled = false;
                obj.transform.parent = gameObject.transform;
                obj.transform.position = gameObject.transform.position + new Vector3(0, -0.5f, 0f);
                var anim = other.gameObject.GetComponent<Animator>();
                changeAnimAction?.Invoke(anim, _type, gameObject.transform.position);
            }
        }
    }
}