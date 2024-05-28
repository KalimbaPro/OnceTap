using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeOut : MonoBehaviour
{
    [SerializeField]
    private Canvas fadeOutCanvas;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        SetAlpha(1f);
        StartCoroutine(FadeMore());
    }

    private void SetAlpha(float alpha)
    {
        var color = image.color;
        color.a = alpha;
        image.color = color;
    }

    private IEnumerator FadeMore()
    {
        SetAlpha(image.color.a - 0.05f);

        yield return new WaitForSeconds(0.01f);

        if (image.color.a > 0)
        {
            StartCoroutine(FadeMore());
        }
        else
        {
            fadeOutCanvas.gameObject.SetActive(false);
        }
    }
}
