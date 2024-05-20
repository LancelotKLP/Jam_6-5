using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private float mapWidth;

    private Transform[] maps;
    private SpriteRenderer[] mapRenderers;

    void Start()
    {
        maps = new Transform[transform.childCount];
        mapRenderers = new SpriteRenderer[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            maps[i] = transform.GetChild(i);
            mapRenderers[i] = maps[i].GetComponent<SpriteRenderer>();
        }
        UpdateMapWidth();
        PositionMaps();
    }

    void Update()
    {
        for (int i = 0; i < maps.Length; i++)
        {
            maps[i].Translate(Vector3.left * scrollSpeed * Time.deltaTime);
            if (maps[i].position.x <= -mapWidth)
            {
                int correspondingIndex = (i % 2 == 0) ? i + 1 : i - 1;
                maps[i].position = new Vector3(maps[correspondingIndex].position.x + mapWidth, maps[i].position.y, maps[i].position.z);
                Debug.Log("Repositioned map " + i + " to: " + maps[i].position); // Debug log
            }
        }
    }

    private void UpdateMapWidth()
    {
        if (mapRenderers[0] != null)
        {
            mapWidth = mapRenderers[0].bounds.size.x;
            Debug.Log("Map Width: " + mapWidth); // Debug log
        }
        else
            Debug.LogError("SpriteRenderer component is missing on map object");
    }

    private void PositionMaps()
    {
        for (int i = 0; i < maps.Length; i += 2)
        {
            if (i < maps.Length)
            {
                maps[i].position = new Vector3(0, maps[i].position.y, maps[i].position.z);
                Debug.Log("Positioning map " + i + " at: " + maps[i].position);
            }
            if (i + 1 < maps.Length)
                maps[i + 1].position = new Vector3(mapWidth, maps[i + 1].position.y, maps[i + 1].position.z);
        }
    }
}
