using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public Transform[] checkpoints;
    private Vector3 targetDirection;
    public int[] scoreThresholds;
    public float baseSpeed = 2f;
    public Text scoreText;

    [HideInInspector]
    public int currentScore = 0;

    void Start()
    {
        if (checkpoints.Length > 0)
            transform.position = checkpoints[0].position;
        UpdateScoreText();
    }

    void Update()
    {
        if (checkpoints.Length < 2 || scoreThresholds.Length < 2) return;
        int currentCheckpointIndex = 0;
        for (int i = 0; i < scoreThresholds.Length - 1; i++) {
            if (currentScore >= scoreThresholds[i] && currentScore < scoreThresholds[i + 1]) {
                currentCheckpointIndex = i;
                break;
            }
        }
        Vector3 startPoint = checkpoints[currentCheckpointIndex].position;
        Vector3 endPoint = checkpoints[currentCheckpointIndex + 1].position;
        int currentThreshold = scoreThresholds[currentCheckpointIndex];
        int nextThreshold = scoreThresholds[currentCheckpointIndex + 1];
        float scoreRange = nextThreshold - currentThreshold;
        float scoreProgress = Mathf.Clamp((float)(currentScore - currentThreshold) / scoreRange, 0f, 1f);
        transform.position = Vector3.Lerp(startPoint, endPoint, scoreProgress);
    }

    public void UpdateScore(int newScore)
    {
        currentScore = newScore;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;
    }
}

