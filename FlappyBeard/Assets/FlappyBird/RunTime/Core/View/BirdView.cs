using FlappyBird.Rintime.Core.Services.BirdMovment.Systems;
using UnityEngine;
using VContainer;

public class BirdView : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private IBirdRotationSystem _rotationSystem;

    public Rigidbody2D Rb => rb;

    [Inject]
    public void Construct(IBirdRotationSystem rotationSystem)
    {
        _rotationSystem = rotationSystem;
    }

    private void FixedUpdate()
    {
        _rotationSystem?.Rotate(transform, rb.linearVelocity);
    }
}
