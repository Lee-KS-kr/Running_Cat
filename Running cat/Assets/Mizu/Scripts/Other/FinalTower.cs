using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class FinalTower : MonoBehaviour
    {
        private int _playerLayer;

        private void Start()
        {
            _playerLayer = LayerMask.NameToLayer("Player");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == _playerLayer)
            {
                GameManager.Inst.StageMng.SetFinalCutscene();
                GameManager.Inst.SoundMng.PlaySFX(SoundManager.Sounds.Win);
            }
        }
    }
}