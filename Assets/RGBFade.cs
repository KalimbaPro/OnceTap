using UnityEngine;
using UnityEngine.UI;

public class RGBFade : MonoBehaviour
{
    private Image image; // Reference to the Image component
    public float fadeSpeed = 1.0f; // Speed of the fade

    private float r, g, b;
    private bool increaseR, increaseG, increaseB;

    void Start()
    {
        image = GetComponent<Image>();

        // Start with red color
        r = 1.0f;
        g = 0.0f;
        b = 0.0f;

        increaseR = false;
        increaseG = true;
        increaseB = false;

        // Initialize image color
        image.color = new Color(r, g, b);
    }

    void Update()
    {
        // Adjust the color channels
        if (increaseR)
        {
            r += fadeSpeed * Time.deltaTime;
            if (r >= 1.0f)
            {
                r = 1.0f;
                increaseR = false;
                increaseG = true;
            }
        }
        else
        {
            r -= fadeSpeed * Time.deltaTime;
            if (r <= 0.0f)
            {
                r = 0.0f;
            }
        }

        if (increaseG)
        {
            g += fadeSpeed * Time.deltaTime;
            if (g >= 1.0f)
            {
                g = 1.0f;
                increaseG = false;
                increaseB = true;
            }
        }
        else
        {
            g -= fadeSpeed * Time.deltaTime;
            if (g <= 0.0f)
            {
                g = 0.0f;
            }
        }

        if (increaseB)
        {
            b += fadeSpeed * Time.deltaTime;
            if (b >= 1.0f)
            {
                b = 1.0f;
                increaseB = false;
                increaseR = true;
            }
        }
        else
        {
            b -= fadeSpeed * Time.deltaTime;
            if (b <= 0.0f)
            {
                b = 0.0f;
            }
        }

        // Update the color of the image
        image.color = new Color(r, g, b);
    }
}
