using System;
using FlappyBird.Rintime.Core.Services.BirdMovment.Meta;
using UnityEngine;

public struct MovementContext
{
    public Guid Id { get;}
    public GameObject TargetObject { get; }
    public GameObjectType Type { get; }
    public MovementRule[] Rules { get; }
    
    public MovementContext(GameObject targetObject, GameObjectType type, MovementRule[] rules)
    {
        Id = Guid.NewGuid();
        TargetObject = targetObject;
        Type = type;
        Rules = rules ?? Array.Empty<MovementRule>();
    }
}
