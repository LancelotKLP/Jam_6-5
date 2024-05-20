using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImageSwitcher : MonoBehaviour
{
    public List<GameObject> leftImageObjects;  // Liste des objets d'images pour la gauche
    public List<GameObject> rightImageObjects; // Liste des objets d'images pour la droite
    public List<int> scoreThresholds;

    private int currentScoreIndex = 0;
    private int currentImageIndex = 0;
    private float updateInterval = 1f; // Interval de mise à jour en secondes
    private float timer = 0f;

    private void Start()
    {
        // Initialisation des images
        DisplayImages();
    }

    private void Update()
    {
        // Met à jour le score à intervalle régulier
        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            timer = 0f;
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        int currentScore = LoadScore();
        if (currentScoreIndex < scoreThresholds.Count && currentScore >= scoreThresholds[currentScoreIndex])
        {
            currentScoreIndex++;
            DisplayImages();
        }
    }

    private int LoadScore()
    {
        string savePath = Application.dataPath + "/../save.db";
        if (File.Exists(savePath))
        {
            try
            {
                string[] lines = File.ReadAllLines(savePath);

                if (lines.Length >= 2)
                {
                    string[] scoreLine = lines[1].Split(':');
                    if (scoreLine.Length >= 2 && int.TryParse(scoreLine[1], out int score))
                    {
                        return score;
                    }
                    else
                    {
                        Debug.LogError("Invalid score format in save file.");
                    }
                }
                else
                {
                    Debug.LogError("Save file does not contain enough lines.");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading save file: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("Save file not found at: " + savePath);
        }
        return 0; // Retourne 0 en cas d'erreur
    }

    private void DisplayImages()
    {
        // Désactiver tous les objets
        foreach (var obj in leftImageObjects)
        {
            obj.SetActive(false);
        }
        foreach (var obj in rightImageObjects)
        {
            obj.SetActive(false);
        }

        // Activer les objets actuels
        if (currentImageIndex < leftImageObjects.Count && currentImageIndex < rightImageObjects.Count)
        {
            leftImageObjects[currentImageIndex].SetActive(true);
            rightImageObjects[currentImageIndex].SetActive(true);

            // Incrémente l'index pour les prochaines images
            currentImageIndex++;
        }
    }
}