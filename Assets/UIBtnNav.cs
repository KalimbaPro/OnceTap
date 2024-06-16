using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIBtnNav : MonoBehaviour
{
    private Button button;

    [SerializeField] private GameObject SelectionIndicator;

    public bool IsSelected = false;

    public UIBtnNav UpBtnNav;
    public UIBtnNav DownBtnNav;
    public UIBtnNav LeftBtnNav;
    public UIBtnNav RightBtnNav;

    public InputActionReference UpInput;
    public InputActionReference DownInput;
    public InputActionReference LeftInput;
    public InputActionReference RightInput;
    public InputActionReference ValidateBtn;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        UpInput.action.performed += ctx => SelectOther(UpBtnNav);
        DownInput.action.performed += ctx => SelectOther(DownBtnNav);
        LeftInput.action.performed += ctx => SelectOther(LeftBtnNav);
        RightInput.action.performed += ctx => SelectOther(RightBtnNav);
        ValidateBtn.action.performed += ctx => OnValidateBtn();
    }

    // Update is called once per frame
    void Update()
    {
        SelectionIndicator.SetActive(IsSelected);
    }

    public void DisableAll()
    {
        IsSelected = false;

        if (UpBtnNav != null) UpBtnNav.DisableAll();
        if (DownBtnNav != null) DownBtnNav.DisableAll();
        if (LeftBtnNav != null) LeftBtnNav.DisableAll();
        if (RightBtnNav != null) RightBtnNav.DisableAll();
    }

    private void SelectOther(UIBtnNav other)
    {
        if (!IsSelected)
        {
            return;
        }

        if (other != null)
        {
            IsSelected = false;
            other.IsSelected = true;
        }
    }

    private void OnValidateBtn()
    {
        if (button != null)
        {
            button.onClick.Invoke();
        }
    }
}
