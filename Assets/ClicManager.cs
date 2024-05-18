using UnityEngine;
using UnityEngine.UI;

public class ClickCounter : MonoBehaviour
{
    public Text counterText;
    private int clickCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Détection des clics de souris gauche
        {
            clickCount++;
            counterText.text = clickCount.ToString();
        }
    }
}
