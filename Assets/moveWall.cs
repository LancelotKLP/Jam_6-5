using UnityEngine;

public class MoveLeftLoop : MonoBehaviour
{
    public float speed = 5f; // Speed of the movement
    public float startX = 10f; // Starting x position
    public float endX = -10f; // Ending x position

    void Update()
    {
        // Move the GameObject left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Check if the GameObject has reached the end position
        if (transform.position.x <= endX)
        {
            // Reset the position to the start position
            Vector3 newPos = transform.position;
            newPos.x = startX;
            transform.position = newPos;
        }
    }
}
