using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class TrackingCamera : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;
        [SerializeField] private Vector3 _offset;

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>();
        }

        private void LateUpdate()
        {
            transform.position = _player.transform.position + _offset;
        }
    }
}