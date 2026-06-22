using FlappyBird.Rintime.Core.Services.BirdMovment;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

public class InputService: IDisposable, IStartable
{
    private readonly PlayerControls _inputActions;
    private readonly IBirdMovmentController _birdMovmentController;

    public InputService(PlayerControls inputActions, IBirdMovmentController birdMovmentController)
    {
        _inputActions = inputActions;
        _birdMovmentController = birdMovmentController;
    }

    public void Dispose()
    {
        _inputActions.Player.Jump.performed -= OnJumpPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext ctx)
    {
        _birdMovmentController.ProcessJump();
    }

    public void Start()
    {
        _inputActions.Player.Enable();


        _inputActions.Player.Jump.performed += OnJumpPerformed;
    }
}
