using FlappyBird.Rintime.Core.Services.BirdMovment;
using FlappyBird.Rintime.Core.Services.BirdMovment.Systems;
using UnityEngine;
using VContainer;

public class BirdView : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    
}
