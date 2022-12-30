using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(CharacterController))]
public class CharacterSystemController : MonoBehaviour
{ 
    private Vector3 _targetPosition;
    private Vector3 _axisInput;

    private CharacterController _characterController;

    private CharacterMover _characterMover;
    private CharacterStats _characterStats;

    private void DisableRagdoll()
    {
        Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rb.Length; i++)
            rb[i].isKinematic = true;
    }

    private void OnEnable()
    {
        _characterController = GetComponent<CharacterController>();
        _characterMover = GetComponent<CharacterMover>();
        _characterStats = GetComponent<CharacterStats>();

        DisableRagdoll();
    }


    private void SetAnimator(Vector3 Axis, float DeltaTime, Transform Body, Vector3 Target)
    {
        _characterMover.SetAnimatorStats(Axis, DeltaTime);
        _characterMover.Move(Body, Target, Axis, DeltaTime);
    }

    private void OnAnimatorIK()
    {
        _characterController.Move(Physics.gravity * Time.deltaTime);
        SetAnimator(_axisInput, Time.deltaTime, transform, _targetPosition);
    }

    public void SetInput(Vector3 Axis, Vector3 Target)
    {
        _axisInput = Axis;
        _targetPosition = Target;
    }

}
