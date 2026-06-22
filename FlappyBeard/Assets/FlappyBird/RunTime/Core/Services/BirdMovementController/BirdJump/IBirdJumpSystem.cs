using UnityEngine;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.Systems
{
    public interface IBirdJumpSystem
    {
        void Jump(Rigidbody2D rb, float force);
    }
}