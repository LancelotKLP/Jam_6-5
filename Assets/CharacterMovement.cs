using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform[] checkpoints;  // Array des checkpoints
    private int currentCheckpointIndex = 0;  // Index du checkpoint actuel
    private Transform currentTarget;  // Checkpoint cible
    public float speed = 2f;  // Vitesse de déplacement

    [HideInInspector]
    public float progress = 0f;  // Progression actuelle
    public float progressSpeed = 0.1f;  // Vitesse de progression

    void Start()
    {
        if (checkpoints.Length > 0)
        {
            currentTarget = checkpoints[currentCheckpointIndex];
            transform.position = currentTarget.position;
        }
    }

    void Update()
    {
        if (currentTarget != null)
        {
            progress += progressSpeed * Time.deltaTime;  // Incrémentation de la progression
            if (progress >= 1f)
            {
                progress = 0f;
                MoveToNextCheckpoint();
            }
            else
            {
                MoveAlongPath();
            }
        }
    }

    void MoveAlongPath()
    {
        if (currentCheckpointIndex < checkpoints.Length - 1)
        {
            Vector3 startPosition = checkpoints[currentCheckpointIndex].position;
            Vector3 endPosition = checkpoints[currentCheckpointIndex + 1].position;
            transform.position = Vector3.Lerp(startPosition, endPosition, progress);
        }
    }

    void MoveToNextCheckpoint()
    {
        if (currentCheckpointIndex < checkpoints.Length - 1)
        {
            currentCheckpointIndex++;
            currentTarget = checkpoints[currentCheckpointIndex];
        }
    }
}

