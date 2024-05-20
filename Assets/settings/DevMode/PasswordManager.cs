using UnityEngine;
using UnityEngine.UI;

public class PasswordManager : MonoBehaviour
{
    public GameObject passwordPanel;
    public InputField passwordInput;
    public GameObject settingsOverlay;
    public GameObject DevModeOL;
    public GameObject settingsPanel;
    private string correctPassword = "31415";

    void Start()
    {
        passwordPanel.SetActive(false);
        settingsPanel.SetActive(false);
        settingsOverlay.SetActive(true);
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void OnDevModeButtonClicked()
    {
        passwordPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void OnBackButtonClicked()
    {
        passwordPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OnSubmitButtonClicked()
    {
        if (passwordInput.text == correctPassword) {
            passwordPanel.SetActive(false);
            settingsPanel.SetActive(true);
            settingsOverlay.SetActive(true);
        }
        passwordInput.text = null;
    }

    public void OnBackSpaceButtonClicked()
    {
        if (!string.IsNullOrEmpty(passwordInput.text))
            passwordInput.text = passwordInput.text.Substring(0, passwordInput.text.Length - 1);
    }

    public void OnNumberButtonClicked(string number)
    {
        passwordInput.text += number;
    }
}
