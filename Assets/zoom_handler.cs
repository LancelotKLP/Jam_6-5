using UnityEngine;

public class ZoomHandler : MonoBehaviour
{
    public Canvas canvas;
    public float zoomSpeed = 0.1f;
    public float minZoom = 0.5f;
    public float maxZoom = 3.0f;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
            Zoom(scroll);
    }

    void Zoom(float increment)
    {
        float newScale = Mathf.Clamp(rectTransform.localScale.x + increment * zoomSpeed, minZoom, maxZoom);
        rectTransform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
