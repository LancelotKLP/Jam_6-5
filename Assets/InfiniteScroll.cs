using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    public float scrollSpeed = 0.3f;
    public float mapWidth = 12.5f;

    private Transform[] maps;

    void Start()
    {
        maps = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            maps[i] = transform.GetChild(i);
        maps[0].position = new Vector3(0, maps[0].position.y, maps[0].position.z);
        maps[1].position = new Vector3(mapWidth, maps[1].position.y, maps[1].position.z);
    }

    void Update()
    {
        foreach (Transform map in maps) {
            map.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
            if (map.position.x <= -mapWidth) {
                Vector3 rightmostMapPosition = GetRightmostMapPosition();
                map.position = new Vector3(rightmostMapPosition.x + mapWidth, map.position.y, map.position.z);
            }
        }
    }

    private Vector3 GetRightmostMapPosition()
    {
        Vector3 rightmostPosition = maps[0].position;
        foreach (Transform map in maps) {
            if (map.position.x > rightmostPosition.x)
                rightmostPosition = map.position;
        }
        return rightmostPosition;
    }
}
