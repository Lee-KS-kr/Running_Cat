using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class Initializer : MonoBehaviour
    {
        private void Awake()
        {
            GameManager.Inst.SoundMng.Initialize();
            GameManager.Inst.UIMng.Initialize();
            GameManager.Inst.StageMng.Initialize();
            GameManager.Inst.ObstacleMnr.Initialize();
        }
    }
}