using StarterAssets;
using System.Collections;
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

    [SerializeField]
    private Camera droneCamera;
    [SerializeField]
    private GameObject strikeCylinder;

    private bool stopping = false;

    private void Start()
    {
        //_controller = GetComponent<CharacterController>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void OnEnable()
    {
        strikeCylinder.SetActive(true);
    }

    private void Update()
    {
        if (!stopping && _input.attack)
        {
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

        droneCamera.transform.position += movement;

        //movement.x = _moveInput.action.ReadValue<Vector2>().x * deltaTime;
        //movement.z = _moveInput.action.ReadValue<Vector2>().y * deltaTime;
    }

    //private void FireStrike()
    //{
    //}

    private IEnumerator LaunchStrike()
    {
        strikeCylinder.GetComponent<CapsuleCollider>().enabled = true;

        yield return new WaitForSeconds(1);

        strikeCylinder.GetComponent<CapsuleCollider>().enabled = false;
        strikeCylinder.SetActive(false);
        _input.launchDrone = false;
        _input.attack = false;
        GetComponent<DroneCamControl>().StopDroneCamera();
        GetComponent<ThirdPersonController>().enabled = true;
        GetComponent<DroneMovement>().enabled = false;
    }
}
