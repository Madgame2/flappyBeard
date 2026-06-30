using System;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace FlappyBird.RunTime.Core.Services
{
    public class InputService : IDisposable, IStartable
    {
        private readonly PlayerControls _inputActions;

        public event Action OnJumpRequested;
        public event Action OnCancelRequested;

        public InputService(PlayerControls inputActions)
        {
            _inputActions = inputActions;
        }

        public void Dispose()
        {
            _inputActions.Player.Disable();

            _inputActions.Player.Jump.performed -= OnJumpPerformed;
            _inputActions.Player.Cancel.performed -= OnCancelPerformed;
        }

        public void Start()
        {
            _inputActions.Player.Enable();

            _inputActions.Player.Jump.performed += OnJumpPerformed;
            _inputActions.Player.Cancel.performed += OnCancelPerformed;
        }
        
        private void OnJumpPerformed(InputAction.CallbackContext ctx)
        {
            OnJumpRequested?.Invoke();
        }
        
        private void OnCancelPerformed(InputAction.CallbackContext ctx)
        {
            OnCancelRequested?.Invoke();
        }
    }
}