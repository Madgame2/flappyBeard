using UnityEngine;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.Systems
{
    public interface IBirdRotationSystem
    {
        void Rotate(Transform birdTransform, Vector2 velocity);
    }
}
