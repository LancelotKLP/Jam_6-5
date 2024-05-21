using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public int gridWidth = 320;
    public int gridHeight = 240;
    public int cellSize = 1;

    private int[,] grid;
    private Color32[] fireColors;
    private Texture2D fireTexture;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        InitializeColors();
        InitializeGrid();

        fireTexture = new Texture2D(gridWidth, gridHeight);
        fireTexture.filterMode = FilterMode.Point;
        fireTexture.wrapMode = TextureWrapMode.Clamp;

        Sprite fireSprite = Sprite.Create(fireTexture, new Rect(0, 0, gridWidth, gridHeight), new Vector2(0.5f, 0.5f), 1);
        spriteRenderer.sprite = fireSprite;
        spriteRenderer.sortingOrder = 21;

        InitializeFireSource();
    }

    void Update()
    {
        UpdateFire();
        DrawFire();
    }

    void InitializeColors()
    {
        fireColors = new Color32[] {
            new Color32(0, 0, 0, 0),
            new Color32(7, 7, 7, 255), new Color32(31, 7, 7, 255), new Color32(47, 15, 7, 255), new Color32(71, 15, 7, 255),
            new Color32(87, 23, 7, 255), new Color32(103, 31, 7, 255), new Color32(119, 31, 7, 255), new Color32(143, 39, 7, 255),
            new Color32(159, 47, 7, 255), new Color32(175, 63, 7, 255), new Color32(191, 71, 7, 255), new Color32(199, 71, 7, 255),
            new Color32(223, 79, 7, 255), new Color32(223, 87, 7, 255), new Color32(223, 87, 7, 255), new Color32(215, 95, 7, 255),
            new Color32(215, 95, 7, 255), new Color32(215, 103, 15, 255), new Color32(207, 111, 15, 255), new Color32(207, 119, 15, 255),
            new Color32(207, 127, 15, 255), new Color32(207, 135, 23, 255), new Color32(199, 135, 23, 255), new Color32(199, 143, 23, 255),
            new Color32(199, 151, 31, 255), new Color32(191, 159, 31, 255), new Color32(191, 159, 31, 255), new Color32(191, 167, 39, 255),
            new Color32(191, 167, 39, 255), new Color32(191, 175, 47, 255), new Color32(183, 175, 47, 255), new Color32(183, 183, 47, 255),
            new Color32(183, 183, 55, 255), new Color32(207, 207, 111, 255), new Color32(223, 223, 159, 255), new Color32(239, 239, 199, 255),
            new Color32(255, 255, 255, 255)
        };
    }

    void InitializeGrid()
    {
        grid = new int[gridHeight, gridWidth];
        for (int y = 0; y < gridHeight; y++) {
            for (int x = 0; x < gridWidth; x++)
                grid[y, x] = 0;
        }
    }

    void InitializeFireSource()
    {
        for (int x = 0; x < gridWidth; x++)
            grid[0, x] = fireColors.Length - 1;
    }

    void UpdateFire()
    {
        for (int y = 1; y < gridHeight; y++) {
            for (int x = 0; x < gridWidth; x++) {
                int decay = Random.Range(0, 4);
                int newValue = grid[y - 1, (x + decay) % gridWidth] - decay;
                grid[y, x] = Mathf.Clamp(newValue, 0, fireColors.Length - 1);
            }
        }
    }

    void DrawFire()
    {
        for (int y = 0; y < gridHeight; y++) {
            for (int x = 0; x < gridWidth; x++)
                fireTexture.SetPixel(x, y, fireColors[grid[y, x]]);
        }
        fireTexture.Apply();
    }
}
