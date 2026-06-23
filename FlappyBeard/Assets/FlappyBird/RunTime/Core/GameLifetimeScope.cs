using FlappyBird.RunTime.Core.Services.Location;
using FlappyBird.RunTime.Core.Services.Spawn;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLigeTimeScope  : LifetimeScope
{
    
    [SerializeField] private LocationPrefabsStorage _prefabsStorage;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_prefabsStorage);

        builder.Register<SpawnSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        
        builder.Register<LocationController>(Lifetime.Singleton).AsImplementedInterfaces();
    }
}
