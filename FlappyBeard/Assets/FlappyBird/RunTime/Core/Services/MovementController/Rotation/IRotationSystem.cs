using UnityEngine;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.Systems
{
    public interface IRotationSystem: IMovementSystem
    {
        void Rotate(Transform birdTransform, IRotationConfig config, Vector2 velocity);
    }
}
