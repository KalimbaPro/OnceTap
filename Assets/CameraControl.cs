using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float minZoomDistance = 5f; // Minimum distance for zooming
    public float maxZoomDistance = 30f; // Maximum distance for unzooming
    public float zoomSpeed = 2f; // Zoom speed
    public Vector3 offset = Vector3.zero; // Offset from the middle point

    private Vector3 _middlePoint = Vector3.zero;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("PlayerCameraTrack").Length > 0)
            _middlePoint = GetAveragePosWithTag("PlayerCameraTrack");
        FollowTargets();
    }

    private void FollowTargets()
    {
        Vector3 desiredPos = _middlePoint + offset * (_camera.transform.position.y - minZoomDistance) / (maxZoomDistance - minZoomDistance); // Scale the offset

        // Calculate the distance between players
        float distance = Vector3.Distance(_middlePoint, Camera.main.transform.position);

        // Adjust camera position based on distance (Y position)
        float targetY = Mathf.Lerp(maxZoomDistance, minZoomDistance, distance / maxZoomDistance / 10);
        desiredPos.y = targetY;

        // Move the camera
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, desiredPos, Time.deltaTime);

        // Look at the middle point
        _camera.transform.LookAt(_middlePoint);
    }

    private Vector3 GetAveragePosWithTag(string tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        Vector3 averagePos = Vector3.zero;
        foreach (GameObject obj in taggedObjects)
        {
            averagePos += obj.transform.position;
        }
        return averagePos / taggedObjects.Length;
    }
}
