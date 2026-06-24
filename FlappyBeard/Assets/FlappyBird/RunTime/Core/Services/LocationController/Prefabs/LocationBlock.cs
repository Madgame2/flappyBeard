using System;
using UnityEngine;
using UnityEngine.Pool;

public class LocationBlock : MonoBehaviour, IMoveable
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _width = 10f; 
    [SerializeField] private MoveStrategyBase[] moveStrateges;
    
    public float Width => _width;
    public  MoveStrategyBase[] MoveStrategies => moveStrateges;
    
    public event Action<LocationBlock> OnRequestRelease;

    public void Deactivate()
    {
        OnRequestRelease?.Invoke(this);
    }

    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Transform Transform => this.transform;
    public GameObject GameObject => this.gameObject;
}
