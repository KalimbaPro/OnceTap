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
    private DroneHUDCanvas droneHUDCanvas;
    [SerializeField]
    private float maxDroneSize = 10;
    [SerializeField]
    private float droneUnzoomSpeed = 1f;
    //[SerializeField]
    //private GameObject strikeCylinder;

    private float initialDroneSize;

    private void Start()
    {
        initialDroneSize = droneCamera.orthographicSize;
    }

    // Start is called before the first frame update
    public void StartDroneCamera()
    {
        droneCamera.orthographicSize = initialDroneSize;
        droneCamera.transform.position = characterCamera.transform.position;
        droneCamera.transform.rotation = characterCamera.transform.rotation;
        droneHUDCanvas.StartHUD();
        //strikeCylinder.SetActive(true);
    }

    public void ChangeCamera()
    {
        characterCamera.enabled = false;
        droneCamera.enabled = true;
    }

    public void StopDroneCamera()
    {
        droneHUDCanvas.StopHUD();
        droneCamera.enabled = false;
        characterCamera.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (droneCamera.orthographicSize < maxDroneSize)
        {
            droneCamera.orthographicSize += droneUnzoomSpeed * Time.deltaTime;
        }
    }
}
