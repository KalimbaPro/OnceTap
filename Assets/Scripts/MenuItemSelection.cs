using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemSelection : MonoBehaviour
{
    //public GameObject Grid;
    public GameObject Border;
    public MenuItemEnum MenuItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SelectMap()
    //{
    //    Grid.GetComponent<MapSelectorGrid>().SelectMap(this);
    //}

    public void BorderSetActive(bool isActive)
    {
        Border.SetActive(isActive);
    }
}
