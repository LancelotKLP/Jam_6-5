using UnityEngine;

public class MoveLeftLoop : MonoBehaviour
{
    public float speed = 5f;
    public float startX = 10f;
    public float endX = -10f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endX) {
            Vector3 newPos = transform.position;
            newPos.x = startX;
            transform.position = newPos;
        }
    }
}
