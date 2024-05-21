using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene management
using UnityEngine.UI; // Needed for UI elements

public class SceneSwitcher : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();   
        if (button != null)
            button.onClick.AddListener(ChangeScene);
        else
            Debug.LogError("No Button component found on this GameObject.");
    }

    void ChangeScene()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("font", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("StreakLost");
    }
}
