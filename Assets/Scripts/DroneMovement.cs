using StarterAssets;
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

    private void Start()
    {
        //_controller = GetComponent<CharacterController>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (_input.attack)
        {
            _input.launchDrone = false;
            _input.attack = false;
            GetComponent<DroneCamControl>().StopDroneCamera();
            GetComponent<ThirdPersonController>().enabled = true;
            GetComponent<DroneMovement>().enabled = false;
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

    private void FireStrike()
    {

    }
}
