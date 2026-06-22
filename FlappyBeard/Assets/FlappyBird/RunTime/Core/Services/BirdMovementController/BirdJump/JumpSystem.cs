using UnityEngine;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.Systems
{
    public class JumpSystem : IBirdJumpSystem
    {
        public void Jump(Rigidbody2D rb, float force)
        {
            rb.linearVelocity = Vector2.zero;

            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}