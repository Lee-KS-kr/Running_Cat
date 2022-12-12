using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public sealed class GameManager
    {
        private static GameManager instance;
        public static GameManager Inst
        {
            get
            {
                if (instance == null)
                    instance = new GameManager();

                return instance;
            }
        }
    }
}