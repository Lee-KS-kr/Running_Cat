using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class SoundManager : MonoBehaviour
    {
        public enum Sounds
        {
            Meow = 0,
            Purr,
            Drink,
            Win,
        }

        private Dictionary<Sounds, AudioClip> sfxDictionary = new Dictionary<Sounds, AudioClip>();
        private AudioSource _audio;
        private AudioClip _clip = null;

        private void Start()
        {
            _audio = gameObject.GetComponent<AudioSource>();
            LoadSounds();
        }

        public void StartGame()
        {
            Debug.Log("Todo : sound mng");
        }

        private void LoadSounds()
        {
            sfxDictionary.Add(Sounds.Meow, Resources.Load<AudioClip>("SFX/Cat_Meow"));
            sfxDictionary.Add(Sounds.Purr, Resources.Load<AudioClip>("SFX/Cat_Purr"));
            sfxDictionary.Add(Sounds.Win, Resources.Load<AudioClip>("/SFX/Cat_Win"));
        }

        public void PlaySFX(Sounds sfxType)
        {
            sfxDictionary.TryGetValue(sfxType, out _clip);
            if (null == _clip) return;
            _audio.PlayOneShot(_clip);
            _clip = null;
        }
    }
}