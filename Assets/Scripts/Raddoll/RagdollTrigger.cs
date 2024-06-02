using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    private enum PlayerState
    {
        Animated,
        Ragdoll
    }
    private Rigidbody[] _ragdollRigidbodies;
    private PlayerState _currentState = PlayerState.Animated;
    private Animator _animator;
    private CharacterController _characterController;

    void Start()
    {
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        Debug.Log(_ragdollRigidbodies.Length.ToString());
        _animator = GetComponentInChildren<Animator>();
        _characterController = GetComponentInChildren<CharacterController>();
        DisableRagdoll();
    }
    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case PlayerState.Animated:
                AnimatedBehaviour();
                break;
            case PlayerState.Ragdoll:
                RagdollBehaviour();
                break;
        }
    }
    void DisableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        _animator.enabled = true;
        _characterController.enabled = true;
    }

    void EnableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        _animator.enabled = false;
        _characterController.enabled = false;
    }

    private void AnimatedBehaviour()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            EnableRagdoll();
            _currentState = PlayerState.Ragdoll;
        }
    }
    private void RagdollBehaviour()
    {

    }
}
