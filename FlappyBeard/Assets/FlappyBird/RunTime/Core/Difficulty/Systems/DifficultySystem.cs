using FlappyBird.RunTime.Core.Difficulty.Data;
using UnityEngine;
using VContainer.Unity;

namespace FlappyBird.RunTime.Core.Difficulty.Systems
{
    namespace FlappyBird.Runtime.Core.Difficulty.Systems
    {
        public class DifficultySystem : ITickable
        {
            private readonly CoreGameplayConfig _config;
            private readonly DifficultyState _state;
            private float _elapsedTime;

            public DifficultySystem(CoreGameplayConfig config, DifficultyState state)
            {
                _config = config;
                _state = state;
                _state.SpeedModifier = _config.StartSpeedModifier;
                _state.SpawnInterval = _config.StartSpawnInterval;
            }

            void ITickable.Tick()
            {
                _elapsedTime += Time.deltaTime;
                
                var progress = Mathf.Clamp01(_elapsedTime / _config.MaxDifficultyTime);
                
                _state.SpeedModifier = _config.StartSpeedModifier * _config.SpeedProgressionCurve.Evaluate(progress);
                _state.SpawnInterval = _config.StartSpawnInterval * _config.SpawnProgressionCurve.Evaluate(progress);
            }
        }
    }
}