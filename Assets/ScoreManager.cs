using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public CharacterMovement characterMovement;

    void Update()
    {
        // Exemple pour ajouter des points (vous pouvez remplacer cela par votre propre logique)
        if (Input.GetKeyDown(KeyCode.L))  // Appuie sur la touche Espace pour ajouter des points
        {
            AddPoints(10);
        }
    }

    public void AddPoints(int points)
    {
        characterMovement.currentScore += points;
    }
}

