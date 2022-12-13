using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public enum ObstacleType
    {
        Juikjuik = 0,
        Naymnaym,
        Mayak,
        CatTower,
    }

    public class Obstacle : MonoBehaviour
    {
        private int _playerLayer = 0;

        private Collider _collider;
        private GameObject _particle;
        public ObstacleType _type = ObstacleType.Juikjuik;
        public Action<Animator, ObstacleType, Vector3> changeAnimAction;

        private void Start()
        {
            _playerLayer = LayerMask.NameToLayer("Player");
            _collider = gameObject.GetComponent<Collider>();
            _particle = gameObject.GetComponentInChildren<ParticleSystem>().gameObject;
            _particle.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _playerLayer)
            {
                other.gameObject.GetComponent<PlayerCat>().enabled = false;
                _collider.enabled = false;
                var anim = other.gameObject.GetComponent<Animator>();
                this.enabled = false;
                _particle.SetActive(true);
                changeAnimAction?.Invoke(anim, _type, gameObject.transform.position);
            }
        }
    }
}