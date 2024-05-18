using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mapScrollView; // Le Scroll View contenant la carte
    public Button mapButton; // Le bouton pour ouvrir la carte

    void Start()
    {
        mapButton.onClick.AddListener(ToggleMap); // Assigner la fonction au bouton
        mapScrollView.SetActive(false); // Assurer que la carte est cachée au début
    }

    void ToggleMap()
    {
        mapScrollView.SetActive(!mapScrollView.activeSelf); // Afficher ou cacher la carte
    }
}
