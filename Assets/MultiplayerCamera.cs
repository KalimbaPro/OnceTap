using UnityEngine;

public class MultiplayerCamera : MonoBehaviour
{
    public Camera activeCamera;
    public Vector3 cameraOffset = Vector3.zero;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = activeCamera.transform.rotation;

        Camera[] allCameras = Camera.allCameras;
        foreach (Camera cam in allCameras)
        {
            cam.enabled = false;
        }

        if (activeCamera != null)
        {
            activeCamera.enabled = true;
        }
        else
        {
            Debug.LogWarning("No active camera specified. Please assign a camera to the activeCamera field.");
        }
    }

    private void LateUpdate()
    {
        //var pos = new Vector3(transform.position.x + cameraOffset);
        activeCamera.transform.position = transform.position + cameraOffset;

        activeCamera.transform.rotation = initialRotation;
    }
}
