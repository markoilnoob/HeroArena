using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace HeroArena
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        private string lastLoadedScene = string.Empty;

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
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void LoadScene(string sceneName)
        {
            if (!IsSceneLoaded(sceneName))
            {
                SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                lastLoadedScene = sceneName;
            }
        }

        public void UnloadScene(string sceneName)
        {
            if (IsSceneLoaded(sceneName))
            {
                SceneManager.UnloadSceneAsync(sceneName);
            }
        }

        private bool IsSceneLoaded(string sceneName)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name == sceneName)
                    return true;
            }
            return false;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Ensure only one EventSystem exists after each scene load
            EventSystem[] eventSystems = FindObjectsByType<EventSystem>(FindObjectsSortMode.None);
            if (eventSystems.Length > 1)
            {
                // Destroy duplicates; this example destroys all but the first one found
                for (int i = 1; i < eventSystems.Length; i++)
                {
                    Destroy(eventSystems[i].gameObject);
                }
            }
        }

        public void QuitApplication()
        {
            // TODO : Create the save game before closing
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
