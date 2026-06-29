using UnityEngine;

namespace FlappyBird.RunTime.Core.Location.Strategies
{
    [CreateAssetMenu(menuName = "Movement/Sine")]
    public class SineMoveStrategy : MoveStrategyBase
    {
        [SerializeField] private float Amplitude = 2f;
        [SerializeField] public float Frequency = 2f;
        public override Vector2 CalculateVelocity(float time, float speedModifier) 
            => new Vector2(0, Mathf.Sin(time * Frequency) * Amplitude);
    }
}