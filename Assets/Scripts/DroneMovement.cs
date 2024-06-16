using MoreMountains.Feedbacks;
using StarterAssets;
using System.Collections;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class DroneMovement : MonoBehaviour
{
    //[SerializeField]
    //private InputActionReference _moveInput;
    //[SerializeField]
    //private InputActionReference _fireInput;
    //private CharacterController _controller;
    private StarterAssetsInputs _input;
    public float DroneSpeed = 1.0f;

    //[SerializeField]
    //private Camera droneCamera;
    [SerializeField]
    private GameObject strikeCylinder;

    private bool stopping = false;

    [SerializeField]
    private GameObject orbitalStrikeHUD;

    [SerializeField]
    private MMF_Player strikeFeedback;

    private void Start()
    {
        //_controller = GetComponent<CharacterController>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void OnEnable()
    {
        stopping = false;
        strikeCylinder.GetComponent<MeshRenderer>().enabled = true;
        strikeCylinder.transform.position = transform.position;
        orbitalStrikeHUD.GetComponent<DroneHUDCanvas>().StartHUD();
    }

    private void OnDisable()
    {
        orbitalStrikeHUD.GetComponent<DroneHUDCanvas>().StopHUD();
    }

    private void Update()
    {
        if (!stopping && _input.attack)
        {
            stopping = true;
            StartCoroutine(LaunchStrike());
        }
        //_input.Clear();
        //if (_fireInput.action.IsPressed())
        //{
        //    FireStrike();
        //}
    }

    private void FixedUpdate()
    {
        var movement = new Vector3();
        var deltaTime = Time.deltaTime;

        movement.x = _input.move.x * deltaTime * DroneSpeed * (_input.sprint ? 2 : 1);
        movement.z = _input.move.y * deltaTime * DroneSpeed * (_input.sprint ? 2 : 1);

        strikeCylinder.transform.position += movement;

        //movement.x = _moveInput.action.ReadValue<Vector2>().x * deltaTime;
        //movement.z = _moveInput.action.ReadValue<Vector2>().y * deltaTime;
    }

    //private void FireStrike()
    //{
    //}

    private IEnumerator LaunchStrike()
    {
        GetComponent<PlayerStats>().IsStrikeReady = false;
        strikeCylinder.GetComponent<CapsuleCollider>().enabled = true;
        orbitalStrikeHUD.GetComponent<DroneHUDCanvas>().StopHUD();
        strikeFeedback.PlayFeedbacks();

        yield return new WaitForSeconds(1);

        strikeCylinder.GetComponent<CapsuleCollider>().enabled = false;
        strikeCylinder.GetComponent<MeshRenderer>().enabled = false;
        _input.launchDrone = false;
        _input.attack = false;
        //GetComponent<DroneCamControl>().StopDroneCamera();
        GetComponent<ThirdPersonController>().InDroneMode = false;
        GetComponent<DroneMovement>().enabled = false;
    }
}
