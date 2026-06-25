using FlappyBird.RunTime.Core.Movement.Interfaces;
using UnityEngine;

public class BirdView : MonoBehaviour, IMoveable
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Transform Transform => transform;
}
