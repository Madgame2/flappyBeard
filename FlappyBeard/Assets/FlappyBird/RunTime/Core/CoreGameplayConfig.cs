using UnityEngine;

namespace FlappyBird.RunTime.Core
{
    [CreateAssetMenu(fileName = "CoreGameplayConfig", menuName = "Game/CoreGameplayConfig")]
    public class CoreGameplayConfig : ScriptableObject
    {
        [Header("Настройки Спавна")] [SerializeField]
        private float _startSpawnInterval = 2f;

        public float StartSpawnInterval => _startSpawnInterval;
        public float CurrentSpawnInterval { get; set; }

        [Header("Множитель Скорости (Сложность)")] [SerializeField]
        private float _startSpeedModifier = 1f;

        public float StartSpeedModifier => _startSpeedModifier;
        public float CurrentSpeedModifier { get; set; }

        [Header("Прогрессия Сложности")]
        [Tooltip("Время в секундах до достижения максимальной сложности")]
        [SerializeField]
        private float _maxDifficultyTime = 300f; // 5 минут

        public float MaxDifficultyTime => _maxDifficultyTime;

        [Tooltip("Ось X: время (0..1), Ось Y: множитель. Например, от 1 до 3")] [SerializeField]
        private AnimationCurve _speedProgressionCurve = AnimationCurve.Linear(0f, 1f, 1f, 3f);

        public AnimationCurve SpeedProgressionCurve => _speedProgressionCurve;

        [Tooltip("Ось X: время (0..1), Ось Y: множитель интервала. Например, от 1 до 0.3 (спавн чаще)")]
        [SerializeField]
        private AnimationCurve _spawnProgressionCurve = AnimationCurve.Linear(0f, 1f, 1f, 0.3f);

        public AnimationCurve SpawnProgressionCurve => _spawnProgressionCurve;

        public void ResetToDefaults()
        {
            CurrentSpawnInterval = _startSpawnInterval;
            CurrentSpeedModifier = _startSpeedModifier;
        }
    }
}