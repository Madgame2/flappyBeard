using FlappyBird.Rintime.Core.Services.BirdMovment;
using FlappyBird.Rintime.Core.Services.BirdMovment.Systems;
using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLigeTimeScope : LifetimeScope
{
    [SerializeField] private BirdView _birdView;
    [SerializeField] private BirdConfig _birdConfig;


    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_birdView);

        builder.RegisterInstance(_birdConfig)
                       .As<IBirdMovementConfig, IBirdRotationConfig>();

        builder.Register<PlayerControls>(Lifetime.Singleton);

        builder.RegisterEntryPoint<InputService>().AsSelf();

        builder.Register<IBirdRotationSystem, BirdRotationSystem>(Lifetime.Singleton);
        builder.Register<IBirdJumpSystem, JumpSystem>(Lifetime.Singleton);
        builder.Register<IBirdMovmentController, BirdMovmentController>(Lifetime.Singleton);
    }
}
