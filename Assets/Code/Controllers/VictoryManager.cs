using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public static VictoryManager Instance;

    public int victoryCount = 0;
    private bool victoryAlreadyCounted = false;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnVictoryImageShown()
    {
        if (victoryAlreadyCounted) return;

        victoryCount++;
        victoryAlreadyCounted = true;

        Debug.Log("Vittorie totali: " + victoryCount);
        CheckUnlocks();
    }

    private void CheckUnlocks()
    {
        if (victoryCount == 1)
            UnlockCharacter("Ranger");

        if (victoryCount == 5)
            UnlockCharacter("Barbarian");

        if (victoryCount == 10)
            UnlockCharacter("Paladin");
    }

    private void UnlockCharacter(string characterName)
    {
        PlayerPrefs.SetInt(characterName + "_Unlocked", 1);
        PlayerPrefs.SetInt("NewCharacterUnlocked", 1); 
        PlayerPrefs.Save();
    }

    public void ResetVictoryFlag()
    {
        victoryAlreadyCounted = false; 
    }
}
