using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public float updateInterval = 1f; // Interval de mise à jour en secondes
    private float timer = 0f;

    void Start()
    {
        string savePath = Application.dataPath + "/../save.db";
        if (File.Exists(savePath))
            LoadScore(savePath);
        else
            Debug.LogError("Save file not found at: " + savePath);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateInterval) {
            timer = 0f;
            UpdateScore();
        }
    }

    void LoadScore(string filePath)
    {
        try {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length >= 2) {
                string[] scoreLine = lines[1].Split(':');
                if (scoreLine.Length >= 2 && int.TryParse(scoreLine[1], out int score))
                    AddPoints(score);
                else
                    Debug.LogError("Invalid score format in save file.");
            }
            else
                Debug.LogError("Save file does not contain enough lines.");
        }
        catch (System.Exception e) {
            Debug.LogError("Error reading save file: " + e.Message);
        }
    }

    void UpdateScore()
    {
        string savePath = Application.dataPath + "/../save.db";
        if (File.Exists(savePath))
            LoadScore(savePath);
        else
            Debug.LogError("Save file not found at: " + savePath);
    }

    public void AddPoints(int points)
    {
        characterMovement.currentScore = points;
    }
}

