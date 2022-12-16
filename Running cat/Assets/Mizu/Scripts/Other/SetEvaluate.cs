using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Mizu
{
    public class SetEvaluate : MonoBehaviour
    {
        private int _playerLayer;
        private int hashGreat = Animator.StringToHash("Great");

        [SerializeField] private TMP_Text text;
        [SerializeField] private Animator _evaluate;

        enum Texts
        {
            Great,
            Awesome,
            Excellent,
        }

        private void Start()
        {
            _playerLayer = LayerMask.NameToLayer("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == _playerLayer)
            {
                SetText();
                gameObject.GetComponent<Collider>().enabled = false;
                _evaluate.SetTrigger(hashGreat);
            }
        }

        private void SetText()
        {
            int rand = Random.Range(0, 3);
            Texts eva = (Texts)rand;
            text.text = $"{eva}";
        }
    }
}