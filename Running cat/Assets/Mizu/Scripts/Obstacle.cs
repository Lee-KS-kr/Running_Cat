using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class Obstacle : MonoBehaviour
    {
        private int _playerLayer = 0;
        private Collider _collider;

        private void Start()
        {
            _playerLayer = LayerMask.NameToLayer("Player");
            _collider = gameObject.GetComponent<Collider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == _playerLayer)
            {
                _collider.enabled = false;
            }
        }
    }
}