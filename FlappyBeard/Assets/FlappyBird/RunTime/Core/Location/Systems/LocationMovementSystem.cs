using FlappyBird.RunTime.Core;
using FlappyBird.RunTime.Core.Difficulty.Data;
using FlappyBird.Runtime.Core.Location.Infrastructure;
using UnityEngine;
using VContainer.Unity;

namespace FlappyBird.Runtime.Core.Location.Systems
{
    public class LocationMovementSystem : IFixedTickable
    {
        private readonly ActiveBlocksRegistry _registry;
        private readonly DifficultyState _difficulty;
        
        public LocationMovementSystem(ActiveBlocksRegistry registry, DifficultyState difficulty)
        {
            _registry = registry;
            _difficulty = difficulty;
        }

        void IFixedTickable.FixedTick()
        {
            var time = Time.time;
            var speedMod = _difficulty.SpeedModifier;

            foreach (var block in _registry.Blocks)
            {
                var totalVelocity = Vector2.zero;
                
                foreach (var strategy in block.MoveStrategies)
                {
                    totalVelocity += strategy.CalculateVelocity(time, speedMod);
                }

                block.Rigidbody2D.linearVelocity = totalVelocity;
            }
        }
    }
}