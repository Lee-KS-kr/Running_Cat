using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mizu
{
    public class UIManager : MonoBehaviour
    {
        private Button _onboardingPanel;
        private GameObject _onboardingUI;

        private void Start()
        {
            _onboardingPanel.onClick.AddListener(GameManager.Inst.StartGame);
        }

        public void StartGame()
        {
            _onboardingUI.SetActive(false);
            Debug.Log("To do : UIManager Startgame");
        }
    }
}