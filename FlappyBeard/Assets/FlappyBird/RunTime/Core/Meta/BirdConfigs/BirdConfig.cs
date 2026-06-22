using FlappyBird.Rintime.Core.Services.BirdMovment.Systems;
using UnityEngine;

[CreateAssetMenu(fileName = "BirdConfig", menuName = "Configs/Bird")]
public class BirdConfig : ScriptableObject, IBirdMovementConfig, IBirdRotationConfig
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _minAngle = -45f;
    [SerializeField] private float _maxAngle = 30f;
    [SerializeField] private float _maxFallSpeed = -8f;

    public float JumpForce => _jumpForce;
    public float MinAngle => _minAngle;
    public float MaxAngle => _maxAngle;
    public float MaxFallSpeed => _maxFallSpeed;
}
