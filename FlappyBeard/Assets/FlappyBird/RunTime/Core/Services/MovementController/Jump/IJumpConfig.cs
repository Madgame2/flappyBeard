using UnityEngine;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.Systems
{
    public interface IJumpConfig: IBaseConfig
    {
        float JumpForce { get; }
    }
}
