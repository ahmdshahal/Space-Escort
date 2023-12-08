using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.InGameActions _inGameActions;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _inGameActions = _playerInput.InGame;

        _playerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        _playerController.Movement();
    }

    private void LateUpdate()
    {
        _playerController.Aim(_inGameActions.Aiming.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _inGameActions.Enable();
    }

    private void OnDisable()
    {
        _inGameActions.Disable();
    }
}
