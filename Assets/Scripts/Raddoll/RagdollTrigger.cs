using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.Netcode;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    public Transform hips;

    private ThirdPersonController third;
    private enum PlayerState
    {
        Animated,
        Ragdoll
    }
    private Rigidbody[] _ragdollRigidbodies;
    private PlayerState _currentState = PlayerState.Animated;
    private Animator _animator;
    private CharacterController _characterController;

    private void Awake()
    {
        third = GetComponent<ThirdPersonController>();
    }

    void Start()
    {
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
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

    void UpdateCharacterRoot()
    {
        transform.position = hips.position;
    }
    public void DisableRagdoll()
    {
        UpdateCharacterRoot();
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        _animator.enabled = true;
        _characterController.enabled = true;
        third.enabled = true;
        _currentState = PlayerState.Animated;

    }

    public void EnableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        _animator.enabled = false;
        third.enabled = false;
        _characterController.enabled = false;
        _currentState = PlayerState.Ragdoll;
    }

    public void ApplyForce(float force, Vector3 direction, ForceMode forceMode)
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.AddForce(direction * force, forceMode);
        }
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


    public void StartRecoveryTime()
    {
        StartCoroutine(DisableRagdollAfterRecoveryTime());
    }
    IEnumerator DisableRagdollAfterRecoveryTime()
        {
            yield return new WaitForSeconds(GetComponent<PlayerStats>().recoveryTime);
            DisableRagdoll();
        }
}
