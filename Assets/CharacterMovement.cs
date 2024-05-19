using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Nécessaire pour utiliser l'élément UI Text

public class CharacterMovement : MonoBehaviour
{
    public Transform[] checkpoints;  // Array des checkpoints
    public int[] scoreThresholds;  // Array des paliers de score pour chaque checkpoint
    public float baseSpeed = 2f;  // Vitesse de base du déplacement
    private Vector3 targetDirection;  // Direction vers le prochain checkpoint

    public Text scoreText;  // Référence à l'élément UI Text pour afficher le score

    [HideInInspector]
    public int currentScore = 0;  // Score actuel

    void Start()
    {
        if (checkpoints.Length > 0)
        {
            // Initialiser la position du personnage au premier checkpoint
            transform.position = checkpoints[0].position;
        }

        // Initialiser l'affichage du score
        UpdateScoreText();
    }

    void Update()
    {
        if (checkpoints.Length < 2 || scoreThresholds.Length < 2) return;

        // Trouver le checkpoint actuel et le prochain checkpoint basé sur le score
        int currentCheckpointIndex = 0;
        for (int i = 0; i < scoreThresholds.Length - 1; i++)
        {
            if (currentScore >= scoreThresholds[i] && currentScore < scoreThresholds[i + 1])
            {
                currentCheckpointIndex = i;
                break;
            }
        }

        // Calculer la position proportionnelle entre le checkpoint actuel et le prochain
        Vector3 startPoint = checkpoints[currentCheckpointIndex].position;
        Vector3 endPoint = checkpoints[currentCheckpointIndex + 1].position;
        int currentThreshold = scoreThresholds[currentCheckpointIndex];
        int nextThreshold = scoreThresholds[currentCheckpointIndex + 1];

        // Calculer la progression du score entre les paliers
        float scoreRange = nextThreshold - currentThreshold;
        float scoreProgress = Mathf.Clamp((float)(currentScore - currentThreshold) / scoreRange, 0f, 1f);

        // Mettre à jour la position de l'objet proportionnellement à la progression du score
        transform.position = Vector3.Lerp(startPoint, endPoint, scoreProgress);

        // Afficher la progression et la position dans la console pour debug
        Debug.Log($"Score actuel: {currentScore}, Progression: {scoreProgress}, Position: {transform.position}");
    }

    public void UpdateScore(int newScore)
    {
        currentScore = newScore;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
}

