using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mizu
{
    public class JellyUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text jellyCount;
        [SerializeField] private static int count = 0;

        private void Start()
        {
            jellyCount = gameObject.GetComponentInChildren<TMP_Text>();

            SetJellyCount(0);
        }

        public void SetJellyCount(int get)
        {
            count += get;
            jellyCount.text = $"{count}";
        }
    }
}