using FlappyBird.Rintime.Core.Services.BirdMovment.Systems;
using UnityEngine;

public class BirdRotationSystem : IBirdRotationSystem
{
    private readonly IBirdRotationConfig _config;

    public BirdRotationSystem(IBirdRotationConfig config)
    {
        _config = config;
    }

    public void Rotate(Transform birdTransform, Vector2 velocity)
    {
        float lerpValue = (velocity.y - _config.MaxFallSpeed) / (0f - _config.MaxFallSpeed + _config.MaxAngle);
        float angle = Mathf.Lerp(_config.MinAngle, _config.MaxAngle, Mathf.Clamp01(lerpValue));

        birdTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
