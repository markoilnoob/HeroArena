using HeroArena;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicTrack", menuName = "Scriptable Objects/MusicTrack")]
public class MusicTrack : ScriptableObject
{
    public SceneNames nameSceneToPlay;
    public AudioClip musicSource;
}
