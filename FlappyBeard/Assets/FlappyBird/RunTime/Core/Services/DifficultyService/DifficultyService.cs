using UnityEngine;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using FlappyBird.RunTime.Core;
using VContainer.Unity; 

public class DifficultyService : IInitializable, IDisposable
{
    private readonly GlobalGameplayConfig _config;
    private CancellationTokenSource _cts;
    private float _elapsedTime;

    public DifficultyService(GlobalGameplayConfig config)
    {
        _config = config;
    }

    public void Initialize()
    {
        _config.ResetToDefaults();
        
        _cts = new CancellationTokenSource();
        DifficultyLoopAsync(_cts.Token).Forget();
    }

    private async UniTaskVoid DifficultyLoopAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            _elapsedTime += Time.deltaTime;
            
            var progress = Mathf.Clamp01(_elapsedTime / _config.MaxDifficultyTime);
            
            var speedCurveValue = _config.SpeedProgressionCurve.Evaluate(progress);
            var spawnCurveValue = _config.SpawnProgressionCurve.Evaluate(progress);
            
            _config.CurrentSpeedModifier = _config.StartSpeedModifier * speedCurveValue;
            _config.CurrentSpawnInterval = _config.StartSpawnInterval * spawnCurveValue;
            
            await UniTask.Yield(PlayerLoopTiming.Update, token);
        }
    }

    public void Dispose()
    {
        _cts?.Cancel();
        _cts?.Dispose();
    }
}
