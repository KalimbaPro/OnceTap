using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject DefMainMenuBtn;
    public GameObject DefSettingsMenuBtn;

    public void SelectSettingsBtn()
    {
        EventSystem.current.SetSelectedGameObject(DefSettingsMenuBtn);
    }

    public void SelectMainBtn()
    {
        EventSystem.current.SetSelectedGameObject(DefMainMenuBtn);
    }
}
