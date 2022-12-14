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
        [SerializeField] private Button _onboardingPanel;
        [SerializeField] private Button _retryButton;
        [SerializeField] private GameObject _failedObj;
        [SerializeField] private GameObject _winObj;
        [SerializeField] private GameObject _ingameObj;
        [SerializeField] private GageUI _gageUI;

        public void Initialize()
        {
            _onboardingPanel = GameObject.Find("Start").GetComponent<Button>();
            _retryButton = GameObject.Find("PlayAgain").GetComponent<Button>();
            _failedObj = GameObject.Find("Failed");
            _winObj = GameObject.Find("Success");
            _ingameObj = GameObject.Find("InGame");
            _gageUI = FindObjectOfType<GageUI>();

            _onboardingPanel.onClick.AddListener(GameManager.Inst.StartGame);
            _retryButton.onClick.AddListener(OnRetryButton);

            _winObj.SetActive(false);
            _failedObj.SetActive(false);
            _retryButton.gameObject.SetActive(false);
            _ingameObj.SetActive(false);
        }

        public void StartGame()
        {
            _onboardingPanel.gameObject.SetActive(false);
            _ingameObj.SetActive(true);
            _gageUI.SetDistance(GameManager.Inst.StageMng.Distance);
            _gageUI.isStart = true;
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
            _retryButton.onClick.RemoveAllListeners();
            _onboardingPanel.onClick.RemoveAllListeners();
            GameManager.Inst.RestartGame();
        }
    }
}