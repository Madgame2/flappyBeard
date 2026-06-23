using FlappyBird.Rintime.Core.Services.BirdMovment.Meta;
using UnityEngine;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.Systems
{
    public class JumpSystem : IJumpSystem
    {
        public void Jump(Rigidbody2D rb, float force)
        {
            rb.linearVelocity = Vector2.zero;

            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

        public MovementType Type =>  MovementType.Jump;
        public void Process(GameObject target, IBaseConfig config)
        {
            if (config is not IJumpConfig jumpConfig)
            {
                return;
            }

            if (!target.TryGetComponent<Rigidbody2D>(out var rb))
            {
                return;
            }
            
            Jump(rb, jumpConfig.JumpForce);
        }
    }
}