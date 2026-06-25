using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using FlappyBird.RunTime.Core.Movement.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace FlappyBird.Rintime.Core.Player.Systems
{
    public class PlayerRotateSystem: IStartable, IDisposable
    {
        private readonly IMoveable _playerObject;
        private readonly PlayerMovementConfig _rotationConfig;

        private CancellationTokenSource _cancellationTokenSource = new();
        
        public PlayerRotateSystem(IMoveable playerObject, PlayerMovementConfig rotationConfig)
        {
            _playerObject = playerObject;
            _rotationConfig = rotationConfig;
        }

        private async UniTaskVoid RotateLoopAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var velocity = _playerObject.Rigidbody2D.linearVelocity;
                var playerTransform = _playerObject.Transform;
                
                var lerpValue = (velocity.y - _rotationConfig.MaxFallSpeed) / (0f - _rotationConfig.MaxFallSpeed + _rotationConfig.MaxAngle);
                var angle = Mathf.Lerp(_rotationConfig.MinAngle, _rotationConfig.MaxAngle, Mathf.Clamp01(lerpValue));

                playerTransform.rotation = Quaternion.Euler(0, 0, angle);
                
                await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
            }
        }
        
        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }

        public void Start()
        {
            RotateLoopAsync(_cancellationTokenSource.Token).Forget();
        }
    }
}