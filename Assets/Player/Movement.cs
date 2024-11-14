using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerController _playerController;
    private InputAction _moveAction;
    private InputAction _fireAction;
    private InputAction _rollAction;
    private InputAction _interactAction;

    private Rigidbody2D _rb;
    [SerializeField] public float moveSpeed;

    private void Awake()
    {
        _playerController = new PlayerController();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _moveAction = _playerController.Default.Move;
        _moveAction.Enable();
        _fireAction = _playerController.Default.Fire;
        _fireAction.Enable();
        _rollAction = _playerController.Default.Roll;
        _rollAction.Enable();
        _interactAction = _playerController.Default.Interact;
        _interactAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _fireAction.Disable();
        _rollAction.Disable();
        _interactAction.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = _moveAction.ReadValue<Vector2>();
        Vector2 vel = _rb.velocity;

        vel.x = moveSpeed * moveDir.x;
        vel.y = moveSpeed * moveDir.y;
        _rb.velocity = vel;
    }
}
