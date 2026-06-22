using UnityEngine;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.Systems
{
    public interface IBirdRotationConfig
    {
        float MinAngle { get; }
        float MaxAngle { get; }
        float MaxFallSpeed { get; }
    }
}
