using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class FinalCutScene : MonoBehaviour
    {
        [SerializeField] private FinalBox[] _boxes;
        public FinalBox[] BoxesPos => _boxes;

        private int needBoxCount = 0;

        private void Start()
        {
            _boxes = transform.GetComponentsInChildren<FinalBox>();
            foreach (var box in _boxes)
                box.gameObject.SetActive(false);
        }

        public void SetBoxCount(int count)
        {
            needBoxCount = count;
            for(int i = 0; i < needBoxCount; i++)
            {
                _boxes[i].gameObject.SetActive(true);
            }

            GameManager.Inst.ObstacleMnr.AddNewObstacle(_boxes);
        }
    }
}