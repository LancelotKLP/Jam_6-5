using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mapScrollView;
    public Button mapButton;

    void Start()
    {
        mapButton.onClick.AddListener(ToggleMap);
        mapScrollView.SetActive(false);
    }

    void ToggleMap()
    {
        mapScrollView.SetActive(!mapScrollView.activeSelf);
    }
}
