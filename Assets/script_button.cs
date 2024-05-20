using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ClickCounter : MonoBehaviour
{
    public Image flameImage;
    public Text counterText;
    public Button upgradeButton;
    private long clickCount;
    private int upgradeLevel = 0;
    private int clicksPerIncrement = 1;
    private int upgradeThreshold = 100;
    private string save = Application.dataPath + "/../save.db";

    void Start()
    {
        if (File.Exists(save))
        {
            string[] lines = File.ReadAllLines(save);
            string[] scoreLine = lines[1].Split(':');
            string[] streakLine = lines[2].Split(':');
            string score = scoreLine[1];
            if (streakLine[1] != "0")
                clickCount = long.Parse(score);
            else {
                clickCount = 0;
                lines[2] = "streak:1";
                File.WriteAllLines(save, lines);
            }
        }
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
        UpdateDB();
    }

    void CheckForUpgrade()
    {
        if (clickCount >= upgradeThreshold)
            upgradeButton.gameObject.SetActive(true);
    }

    void OnUpgradeButtonClick()
    {
        upgradeLevel++;
        clicksPerIncrement += 10;
        clickCount -= upgradeThreshold;
        upgradeThreshold += 200;
        upgradeButton.gameObject.SetActive(false);
        Debug.Log("Upgraded to level " + upgradeLevel + "! Clicks per increment: " + clicksPerIncrement);
        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        counterText.text = clickCount.ToString() + " m";
    }

    void UpdateDB()
    {
        Debug.Log("Saved score: " + clickCount);
        string save = Application.dataPath + "/../save.db";

        if (File.Exists(save))
        {
            string[] lines = File.ReadAllLines(save);
            lines[1] = "score:" + clickCount;
            File.WriteAllLines(save, lines);
        }
    }
}
