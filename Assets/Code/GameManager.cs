using UnityEditor;
using UnityEngine;
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
            LoadScene("SCN_SplashScreen");
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
