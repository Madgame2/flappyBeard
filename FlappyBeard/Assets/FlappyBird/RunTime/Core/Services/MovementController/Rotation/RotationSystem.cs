using FlappyBird.Rintime.Core.Services.BirdMovment;
using FlappyBird.Rintime.Core.Services.BirdMovment.Meta;
using FlappyBird.Rintime.Core.Services.BirdMovment.Systems;
using UnityEngine;

public class RotationSystem : IRotationSystem
{
    public MovementType Type => MovementType.Rotation;
    
    public void Rotate(Transform birdTransform,IRotationConfig config, Vector2 velocity)
    {
        float lerpValue = (velocity.y - config.MaxFallSpeed) / (0f - config.MaxFallSpeed + config.MaxAngle);
        float angle = Mathf.Lerp(config.MinAngle, config.MaxAngle, Mathf.Clamp01(lerpValue));

        birdTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    
    public void Process(GameObject target, IBaseConfig config)
    {
        if (config is not IRotationConfig rotationConfig)
        {
            return;
        }

        var velocity = rotationConfig.GetVelocity(target);
        Rotate(target.transform, rotationConfig, velocity);
    }
}
