using UnityEngine;

public class TextureAnimation : MonoBehaviour
{
    public Vector2 scrollSpeed = new Vector2(0.1f, 0f); // Vitesse de défilement de la texture (horizontale, verticale)
    private Renderer terrainRenderer;

    void Start()
    {
        terrainRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Calculez le décalage de texture en fonction du temps
        float offsetX = Time.time * scrollSpeed.x;
        float offsetY = Time.time * scrollSpeed.y;

        // Appliquez le décalage de texture au matériau du terrain
        terrainRenderer.material.SetTextureOffset("WaterLayer", new Vector2(offsetX, offsetY));
    }
}
