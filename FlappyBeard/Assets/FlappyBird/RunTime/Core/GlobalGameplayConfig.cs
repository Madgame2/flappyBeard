using UnityEngine;

namespace FlappyBird.RunTime.Core
{
    [CreateAssetMenu(fileName = "GlobalGameplayConfig", menuName = "Game/GlobalGameplayConfig")]
    public class GlobalGameplayConfig : ScriptableObject
    {
        [Header("Настройки Спавна")] 
        [SerializeField] private float startSpawnInterval = 2f;
        public float StartSpawnInterval => startSpawnInterval;
        public float CurrentSpawnInterval { get; set; }

        [Header("Множитель Скорости (Сложность)")]
        [SerializeField] private float startSpeedModifier = 1f;
        public float StartSpeedModifier => startSpeedModifier;
        public float CurrentSpeedModifier { get; set; }

        [Header("Прогрессия Сложности")]
        [Tooltip("Время в секундах до достижения максимальной сложности")]
        [SerializeField] private float maxDifficultyTime = 300f; // 5 минут
        public float MaxDifficultyTime => maxDifficultyTime;

        [Tooltip("Ось X: время (0..1), Ось Y: множитель. Например, от 1 до 3")]
        [SerializeField] private AnimationCurve speedProgressionCurve = AnimationCurve.Linear(0f, 1f, 1f, 3f);
        public AnimationCurve SpeedProgressionCurve => speedProgressionCurve;

        [Tooltip("Ось X: время (0..1), Ось Y: множитель интервала. Например, от 1 до 0.3 (спавн чаще)")]
        [SerializeField] private AnimationCurve spawnProgressionCurve = AnimationCurve.Linear(0f, 1f, 1f, 0.3f);
        public AnimationCurve SpawnProgressionCurve => spawnProgressionCurve;

        public void ResetToDefaults()
        {
            CurrentSpawnInterval = startSpawnInterval;
            CurrentSpeedModifier = startSpeedModifier;
        }
    }
}