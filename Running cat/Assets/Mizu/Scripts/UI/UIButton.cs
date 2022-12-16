using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mizu
{
    public class UIButton : MonoBehaviour
    {
        public enum Buttons
        {
            SoundBtn,
            VibBtn,
        }

        [SerializeField] private Image _background;
        [SerializeField] private Image _buttonImage;
        [SerializeField] private Button _button;
        public Buttons thisType;

        [SerializeField] Color beforeColor = new Color(0 / 255f, 55 / 255f, 255 / 255f);
        [SerializeField] Color afterColor = new Color(0 / 255f, 12 / 255f, 56 / 255f);
        [SerializeField] Sprite spriteBefore;
        [SerializeField] Sprite spriteAfter;

        private bool isClicked = false;

        private void Start()
        {
            _button = gameObject.GetComponent<Button>();
            //_background = transform.Find("Background").GetComponent<Image>();
            //_buttonImage = transform.Find("Image").GetComponent<Image>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        public void Initialize()
        {
            switch (thisType)
            {
                case Buttons.SoundBtn:
                    spriteBefore = Resources.Load<Sprite>("Otter/Arts/Sprite/Sound");
                    spriteAfter = Resources.Load<Sprite>("Otter/Arts/Sprite/Sound X");
                    break;
                case Buttons.VibBtn:
                    spriteBefore = Resources.Load<Sprite>("Otter/Arts/Sprite/Vibration");
                    spriteAfter = Resources.Load<Sprite>("Otter/Arts/Sprite/Vibration X");
                    break;
                default: break;
            }

            _buttonImage.sprite = !isClicked ? spriteBefore : spriteAfter;
            _background.color = !isClicked ? beforeColor : afterColor;
        }

        private void OnButtonClicked()
        {
            isClicked = !isClicked;
            _buttonImage.sprite = !isClicked ? spriteBefore : spriteAfter;
            _background.color = !isClicked ? beforeColor : afterColor;

            switch(thisType)
            {
                case Buttons.SoundBtn:
                    GameManager.Inst.SoundMng.OnMute(isClicked);
                    break;
                case Buttons.VibBtn:
                    break;
                default:break;
            }
        }
    }
}