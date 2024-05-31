using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneHUDCanvas : MonoBehaviour
{
    [SerializeField]
    private Image background;
    [SerializeField]
    private List<GameObject> uiObjects = new List<GameObject>();
    [SerializeField]
    private float fadeInSpeed = 5f;
    [SerializeField]
    private float fadeOutSpeed = 1f;
    //[SerializeField]
    //private DroneCamControl camControl;

    private bool reverse = false;

    // Start is called before the first frame update
    void Start()
    {
        StopHUD();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!background.enabled) return;

        var dt = Time.deltaTime;

        if (!reverse)
        {
            if (background.color.a >= 1)
            {
                //camControl.ChangeCamera();
                reverse = true;
            }
            background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a + (fadeInSpeed * dt));
        }
        else
        {
            if (background.color.a <= 0)
            {
                background.enabled = false;
            }
            background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a - (fadeOutSpeed * dt));
            foreach (var item in uiObjects)
            {
                item.GetComponent<Image>().color = new Color(item.GetComponent<Image>().color.r, item.GetComponent<Image>().color.g, item.GetComponent<Image>().color.b, item.GetComponent<Image>().color.a + (fadeOutSpeed * dt));
            }
        }
    }

    public void StartHUD()
    {
        reverse = false;
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0);
        background.enabled = true;
        foreach (var item in uiObjects)
        {
            item.SetActive(true);
            item.GetComponent<Image>().color = new Color(item.GetComponent<Image>().color.r, item.GetComponent<Image>().color.g, item.GetComponent<Image>().color.b, 0);
        }
    }

    public void StopHUD()
    {
        background.enabled = false;
        foreach (var item in uiObjects)
        {
            item.SetActive(false);
        }
    }
}
