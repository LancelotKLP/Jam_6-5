using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene management
using UnityEngine.UI; // Needed for UI elements

public class SceneSwitcher : MonoBehaviour
{
    void Start()
    {
        // Get the Button component attached to the same GameObject
        Button button = GetComponent<Button>();
        
        if (button != null)
        {
            // Add a listener to call the ChangeScene method when the button is clicked
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("No Button component found on this GameObject.");
        }
    }

    void ChangeScene()
    {
        // Load the specified scene
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("font", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("StreakLost");
    }
}
