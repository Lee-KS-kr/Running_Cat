using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public enum TowerStep
    {
        Floors = 3,
        GroundFloor = 5,
    }

    public class CatTowerStep : MonoBehaviour
    {
        private int _playerLayer;
        [SerializeField] private bool isCatSit;
        public TowerStep thisStep = TowerStep.Floors;

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
                if (isCatSit) return;

                var obj = collision.gameObject;
                isCatSit = true;
                this.enabled = false;
                obj.GetComponent<PlayerCat>().enabled = false;
                obj.transform.parent = gameObject.transform;
                obj.transform.position = gameObject.transform.position;
                var anim = collision.gameObject.GetComponent<Animator>();
                changeAnimAction?.Invoke(anim, _type, gameObject.transform.position);
            }
        }
    }
}