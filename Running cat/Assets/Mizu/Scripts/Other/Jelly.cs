using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class Jelly : MonoBehaviour
    {
        private int _playerLayer = 0;

        private void Start()
        {
            _playerLayer = LayerMask.NameToLayer("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == _playerLayer)
            {
                // jelly count ++;
                GameManager.Inst.UIMng.JellyUI.SetJellyCount(1);
                gameObject.SetActive(false);
            }
        }
    }
}