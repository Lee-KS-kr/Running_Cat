using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Mizu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button _onboardingPanel;
        [SerializeField] private Button _retryButton;
        [SerializeField] private GameObject _failedObj;
        [SerializeField] private GameObject _winObj;

        private void Start()
        {
            _onboardingPanel.onClick.AddListener(GameManager.Inst.StartGame);
            _retryButton.onClick.AddListener(OnRetryButton);
            _retryButton.gameObject.SetActive(false);
        }

        public void StartGame()
        {
            _onboardingPanel.gameObject.SetActive(false);
        }

        public void FailedGame()
        {
            _failedObj.SetActive(true);
            _retryButton.gameObject.SetActive(true);
        }

        public void WinGame()
        {
            _winObj.SetActive(true);
            _retryButton.gameObject.SetActive(true);
        }

        private void OnRetryButton()
        {
            SceneManager.LoadScene(0);
        }
    }
}