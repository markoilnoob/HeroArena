using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        private AudioSource audioSource;

        [SerializeField] private Dictionary<string, AudioClip> musicList;
        [SerializeField] private Dictionary<string, AudioClip> sfxList;

        private bool IsMusicPlaying = false;

        //Singleton
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void AddMusic(string musicName, AudioClip music)
        {
            if (!musicName.Trim().Equals(string.Empty) || musicName == null)
                musicList.Add(musicName, music);
            else
                Debug.LogWarning("Audio clip not valid or the name is null");
        }

        public void PlayMusic()
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogError("The audio source is not assigned");
            }

            //if (musicList.Count > 0 && IsMusicPlaying)
            //{

            //}
        }
    }
}
