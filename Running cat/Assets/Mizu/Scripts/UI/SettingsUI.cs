using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mizu
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private GameObject settingsUI;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private UIButton[] buttons;

        private void Start()
        {
            settingsButton = gameObject.GetComponent<Button>();
            settingsUI = GameObject.Find("Level1");
            buttons = GetComponentsInChildren<UIButton>();

            settingsButton.onClick.AddListener(OnSettingsButton);
            exitButton.onClick.AddListener(OnExitButton);

            settingsUI.SetActive(false);
        }

        private void OnSettingsButton()
        {
            settingsUI.SetActive(true);
            foreach (var btn in buttons)
                btn.Initialize();
        }

        private void OnExitButton()
        {
            settingsUI.SetActive(false);
        }
    }
}