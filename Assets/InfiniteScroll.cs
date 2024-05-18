using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float mapWidth = 20f; // Ajuste cette valeur à la largeur de ta map

    private Transform[] maps;

    void Start()
    {
        // Initialiser les références aux maps
        maps = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            maps[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        // Déplacer chaque map vers la gauche
        foreach (Transform map in maps)
        {
            map.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            // Réinitialiser la position si la map est complètement sortie de l'écran
            if (map.position.x <= -mapWidth)
            {
                Vector3 resetPosition = map.position;
                resetPosition.x += mapWidth * 2;
                map.position = resetPosition;
            }
        }
    }
}
