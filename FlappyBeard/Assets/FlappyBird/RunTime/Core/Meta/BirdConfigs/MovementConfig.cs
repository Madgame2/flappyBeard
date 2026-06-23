using FlappyBird.Rintime.Core.Services.BirdMovment.Systems;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementConfig", menuName = "Configs/MovementConfig")]
public class MovementConfig : ScriptableObject, IJumpConfig, IRotationConfig
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _minAngle = -45f;
    [SerializeField] private float _maxAngle = 30f;
    [SerializeField] private float _maxFallSpeed = -8f;


    public float JumpForce => _jumpForce;
    public float MinAngle => _minAngle;
    public float MaxAngle => _maxAngle;
    public float MaxFallSpeed => _maxFallSpeed;
    public Vector2 GetVelocity(GameObject target)
    {
        if (target.TryGetComponent<Rigidbody2D>(out var rb))
        {
            return rb.linearVelocity;
        }
        return Vector2.zero;
    }
}
