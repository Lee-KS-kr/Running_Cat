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
            Hiss,
            Drink,
            Win,
            XylophoneC1,
            XylophoneD,
            XylophoneE,
            XylophoneF,
            XylophoneG,
            XylophoneA,
            XylophoneB,
            XylophoneC2,
        }

        private Dictionary<Sounds, AudioClip> sfxDictionary;
        private AudioSource _audio;
        private AudioClip _clip = null;

        public void Initialize()
        {
            _audio = gameObject.GetComponent<AudioSource>();
            LoadSounds();
        }

        public void StartGame()
        {
            
        }

        private void LoadSounds()
        {
            sfxDictionary = new Dictionary<Sounds, AudioClip>();

            sfxDictionary.Add(Sounds.Meow, Resources.Load<AudioClip>("SFX/Cat/Cat_Meow"));
            sfxDictionary.Add(Sounds.Purr, Resources.Load<AudioClip>("SFX/Cat/Cat_Purr"));
            sfxDictionary.Add(Sounds.Hiss, Resources.Load<AudioClip>("SFX/Cat/Cat_Hiss"));
            sfxDictionary.Add(Sounds.Drink, Resources.Load<AudioClip>("SFX/Cat/Cat_Drink"));
            sfxDictionary.Add(Sounds.Win, Resources.Load<AudioClip>("SFX/Cat/Cat_Win"));
            sfxDictionary.Add(Sounds.XylophoneC1, Resources.Load<AudioClip>("SFX/Xylophone/Xylophone_C1"));
            sfxDictionary.Add(Sounds.XylophoneD, Resources.Load<AudioClip>("SFX/Xylophone/Xylophone_D"));
            sfxDictionary.Add(Sounds.XylophoneE, Resources.Load<AudioClip>("SFX/Xylophone/Xylophone_E"));
            sfxDictionary.Add(Sounds.XylophoneF, Resources.Load<AudioClip>("SFX/Xylophone/Xylophone_F"));
            sfxDictionary.Add(Sounds.XylophoneG, Resources.Load<AudioClip>("SFX/Xylophone/Xylophone_G"));
            sfxDictionary.Add(Sounds.XylophoneA, Resources.Load<AudioClip>("SFX/Xylophone/Xylophone_A"));
            sfxDictionary.Add(Sounds.XylophoneB, Resources.Load<AudioClip>("SFX/Xylophone/Xylophone_B"));
            sfxDictionary.Add(Sounds.XylophoneC2, Resources.Load<AudioClip>("SFX/Xylophone/Xylophone_C2"));
        }

        public void PlaySFX(Sounds sfxType)
        {
            sfxDictionary.TryGetValue(sfxType, out _clip);
            if (null == _clip) return;
            _audio.PlayOneShot(_clip);
            _clip = null;
        }

        public void OnRestart()
        {
            sfxDictionary.Clear();
        }
    }
}