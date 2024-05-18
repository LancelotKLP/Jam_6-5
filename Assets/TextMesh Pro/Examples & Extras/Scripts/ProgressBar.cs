using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;  // Référence à l'UI Slider
    public CharacterMovement characterMovement;  // Référence au script de mouvement

    void Update()
    {
        slider.value = characterMovement.progress;
    }
}

