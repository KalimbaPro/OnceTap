using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCamControl : MonoBehaviour
{
    [SerializeField]
    private Camera characterCamera;
    [SerializeField]
    private Camera droneCamera;
    [SerializeField]
    private GameObject droneHUDCanvas;

    // Start is called before the first frame update
    public void StartDroneCamera()
    {
        droneCamera.transform.position = characterCamera.transform.position;
        droneCamera.transform.rotation = characterCamera.transform.rotation;
        characterCamera.enabled = false;
        droneCamera.enabled = true;
        droneHUDCanvas.SetActive(true);
    }

    public void StopDroneCamera()
    {
        droneHUDCanvas.SetActive(false);
        droneCamera.enabled = false;
        characterCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
