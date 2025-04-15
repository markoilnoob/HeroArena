using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

namespace HeroArena
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Audio Sources")]
        public AudioSource musicSource;
        public AudioSource sfxSource;

        [Header("Scene Audio Data")]
        public List<SceneAudioSO> sceneAudioList;

        Coroutine fadeMusic;

        private Dictionary<SceneNames, AudioClip> sceneMusicMap;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            InitializeMusicMap();
        }

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            PlayMusicForScene(GetCurrentSceneEnum(scene));
            Debug.Log("OnSceneLoaded");
        }

        private void InitializeMusicMap()
        {
            sceneMusicMap = new Dictionary<SceneNames, AudioClip>();
            foreach (var entry in sceneAudioList)
            {
                if (sceneMusicMap.ContainsKey(entry.scene))
                {
                    Debug.LogWarning("Problem in the key,change the value in the ScriptableObject");
                    continue;

                }
                sceneMusicMap.Add(entry.scene, entry.musicClip);
            }
        }

        public void PlayMusicForScene(SceneNames scene)
        {
            if (sceneMusicMap.TryGetValue(scene, out AudioClip clip))
            {
                PlayMusic(clip);
                Debug.Log("PlayMusicForScene");
            }
        }

        public void PlayMusic(AudioClip clip)
        {
            if (musicSource.clip != clip)
            {
                musicSource.clip = clip;
                musicSource.Play();
            }
        }

        public void StopMusic()
        {
            if (fadeMusic == null)
                fadeMusic = StartCoroutine(Fade(false));
            else
                Debug.LogWarning("The volume is already been changed");
        }

        IEnumerator Fade(bool IsFadeIn)
        {
            float currentVolume = (IsFadeIn) ? 0f : 1f;
            float targetVolume = (IsFadeIn) ? 1f : 0f;
            
            while (currentVolume != targetVolume)
            {
                currentVolume += (IsFadeIn) ? Time.deltaTime : -Time.deltaTime;
                currentVolume = Mathf.Clamp01(currentVolume);
                musicSource.volume = currentVolume;
                yield return null;
            }
            fadeMusic = null;
        }

        public void PlaySFX(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip);
        }

        private SceneNames GetCurrentSceneEnum(Scene scene)
        {
            //return (SceneName)sceneIndex;

            switch (scene.buildIndex)
            {
                case 0:
                    return SceneNames.SCN_Main;
                case 1:
                    return SceneNames.SCN_SplashScreen;
                case 2:
                    return SceneNames.SCN_MainMenu;       //stessa cosa sopra
                case 3:
                    return SceneNames.SCN_Game;
                default:
                    return SceneNames.SCN_Main;
            }
        }


    }
}
