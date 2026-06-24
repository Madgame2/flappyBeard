using FlappyBird.Rintime.Core.Services.BirdMovment.Meta;
using FlappyBird.RunTime.Core;
using UnityEngine;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.LinearMotion
{
    public class LinearMotionSystem: ILinearMotionSystem
    {

        private GlobalGameplayConfig _gameplayConfig;

        private LinearMotionSystem(GlobalGameplayConfig gameplayConfig)
        {
            _gameplayConfig = gameplayConfig;
        }
        
        public MovementType Type => MovementType.Linear;
        public void Process(IMoveable target, IBaseMoveConfig config)
        {
            if (config is not ILinearConfig linearConfig)
            {
                return;
            }
            
            float currentMultiplier = GetMultiplier(config.ModifierGroup);
            
            float finalSpeed = linearConfig.Speed * currentMultiplier;
            
            target.GameObject.transform.Translate(linearConfig.Direction * (finalSpeed * Time.deltaTime));
        }
        
        private float GetMultiplier(MovementModifierGroup group)
        {
            return group switch
            {
                MovementModifierGroup.ObstacleDifficulty => _gameplayConfig.CurrentSpeedModifier,
                MovementModifierGroup.None => 1f,
                _ => 1f
            };
        }
    }
}