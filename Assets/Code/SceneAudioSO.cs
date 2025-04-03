using HeroArena;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneAudioSO", menuName = "Scriptable Objects/SceneAudioSO")]
public class SceneAudioSO : ScriptableObject
{
    public SceneNames scene;
    public AudioClip musicClip;
}
