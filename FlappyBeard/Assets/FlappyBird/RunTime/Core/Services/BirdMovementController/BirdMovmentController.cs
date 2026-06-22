using Cysharp.Threading.Tasks;
using FlappyBird.Rintime.Core.Services.BirdMovment.Systems;
using System;
using System.Threading;
using UnityEngine;


namespace FlappyBird.Rintime.Core.Services.BirdMovment
{
    public class BirdMovmentController : IBirdMovmentController, IDisposable
    {
        private readonly BirdView _birdObject;
        private readonly IBirdJumpSystem _jumpSystem;
        private readonly IBirdMovementConfig _config;
        private bool _isGameRunning;
        

        public BirdMovmentController(BirdView birdObject, IBirdJumpSystem jumpSystem, IBirdMovementConfig birdConfig)
        {
            _birdObject = birdObject;
            _jumpSystem = jumpSystem;
            _config = birdConfig;

            _isGameRunning = true;
        }


        public void ProcessJump()
        {
            if (!_isGameRunning) return;

            _jumpSystem.Jump(_birdObject.Rb, _config.JumpForce);
        }

        public void Dispose()
        {
            _isGameRunning = false;
        }
    }
}
