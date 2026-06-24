using FlappyBird.Rintime.Core.Services.BirdMovment;
using FlappyBird.Rintime.Core.Services.BirdMovment.LinearMotion;
using FlappyBird.Rintime.Core.Services.BirdMovment.Meta;
using FlappyBird.RunTime._Temp;
using UnityEngine;

[CreateAssetMenu(fileName = "LinearMoveStrategy", menuName = "ObstaclesStrategy/LinearMoveStrategy")]
public class LinearMoveStrategy : MoveStrategyBase, ILinearConfig
{
    [SerializeField] private MovementModifierGroup modifierGroup =  MovementModifierGroup.ObstacleDifficulty; 
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed = 5f; 

    public Vector2 Direction => direction;
    public float Speed => speed;

    public override MovementType MovementType => MovementType.Linear;
    public override IBaseMoveConfig MoveConfig => this;
    public MovementModifierGroup ModifierGroup => modifierGroup;
}
