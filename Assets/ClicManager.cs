using UnityEngine;
using UnityEngine.UI;

public class ClicksCounter : MonoBehaviour
{
    public Text counterText;
    private int clickCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            clickCount++;
            counterText.text = clickCount.ToString();
        }
    }
}
