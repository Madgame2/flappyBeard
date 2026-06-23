using UnityEngine;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.LinearMotion
{
    public interface ILinearConfig: IBaseConfig
    {
        public Vector2 Direction { get; }
        public float Speed { get; }
    }
}