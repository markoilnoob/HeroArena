using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuUnlockUI : MonoBehaviour
{
    public GameObject notificationPanel;
    public Text messageText;

    public Button arciereButton;
    public Button vichingoButton;
    public Button paladinoButton;

    private void Start()
    {
        UpdateButtonStates();

        if (PlayerPrefs.GetInt("NewCharacterUnlocked", 0) == 1)
        {
            ShowUnlockMessage();
            PlayerPrefs.SetInt("NewCharacterUnlocked", 0);
        }
    }

    private void UpdateButtonStates()
    {
        arciereButton.interactable = PlayerPrefs.GetInt("Arciere_Unlocked", 0) == 1;
        vichingoButton.interactable = PlayerPrefs.GetInt("Vichingo_Unlocked", 0) == 1;
        paladinoButton.interactable = PlayerPrefs.GetInt("Paladino_Unlocked", 0) == 1;
    }

    private void ShowUnlockMessage()
    {
        notificationPanel.SetActive(true);
        messageText.text = "Hai sbloccato un personaggio!";
        StartCoroutine(HideMessageAfterDelay());
    }

    private IEnumerator HideMessageAfterDelay()
    {
        float timer = 0f;
        while (timer < 10f)
        {
            if (Input.anyKeyDown)
                break;

            timer += Time.deltaTime;
            yield return null;
        }

        notificationPanel.SetActive(false);
    }
}