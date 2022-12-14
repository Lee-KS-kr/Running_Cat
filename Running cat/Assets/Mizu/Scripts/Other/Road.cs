using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class Road : MonoBehaviour
    {
        private bool isEnding = false;

        private void Update()
        {
            if (!isEnding) return;
            transform.position += -transform.forward * 20f * Time.deltaTime;
        }

        public void StartEnding(bool isTrue)
        {
            isEnding = isTrue;
        }
    }
}