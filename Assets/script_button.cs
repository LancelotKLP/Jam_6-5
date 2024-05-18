using UnityEngine;
using UnityEngine.UI;

public class ClicksCounter : MonoBehaviour
{
    public Button flameImage;
    public Text counterText;
    public Button upgradeButton;
    private int clickCount = 0;
    private int upgradeLevel = 0;
    private int clicksPerIncrement = 1;
    private int upgradeThreshold = 100;

    void Start()
    {
        UpdateCounterText();
        flameImage.GetComponent<Button>().onClick.AddListener(OnImageClick);
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        upgradeButton.gameObject.SetActive(false);
        InvokeRepeating("IncrementClickCount", 1f, 1f);
    }

    void OnImageClick()
    {
        clickCount += clicksPerIncrement;
        CheckForUpgrade();
        UpdateCounterText();
    }

    void IncrementClickCount()
    {
        clickCount += clicksPerIncrement;
        CheckForUpgrade();
        UpdateCounterText();
    }

    void CheckForUpgrade()
    {
        if (clickCount >= upgradeThreshold)
        {
            upgradeButton.gameObject.SetActive(true);
        }
    }

    // Method to handle the upgrade button click
    void OnUpgradeButtonClick()
    {
        upgradeLevel++;
        clicksPerIncrement += 5;
        clickCount -= upgradeThreshold;
        upgradeThreshold += 100;
        upgradeButton.gameObject.SetActive(false);
        Debug.Log("Upgraded to level " + upgradeLevel + "! Clicks per increment: " + clicksPerIncrement);
        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        counterText.text = "Score:\n" + clickCount.ToString();
    }
}
