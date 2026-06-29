using FlappyBird.RunTime.Core.Player.Configs;
using FlappyBird.RunTime.Core.Player.Input;
using FlappyBird.RunTime.Core.Player.Systems;
using FlappyBird.RunTime.Core.Services;
using FlappyBird.RunTime.Core.View;
using FlappyBird.RunTime.Core.Difficulty.Data;
using FlappyBird.RunTime.Core.Difficulty.Systems.FlappyBird.Runtime.Core.Difficulty.Systems;
using FlappyBird.Runtime.Core.Location.Infrastructure;
using FlappyBird.Runtime.Core.Location.Systems;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FlappyBird.RunTime.Core
{
    public class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private BirdView _playerView;
        [SerializeField] private PlayerMovementConfig _playerMovementConfig;
        [SerializeField] private LocationPrefabsStorage _prefabsStorage;
	    [SerializeField] private ObstacleSpawnPointRoot _obstacleSpawnPointRoot;
	    [SerializeField] private CoreGameplayConfig _gameplayConfig;
	    [SerializeField] private UIConfig _uiConfig;
    
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_playerView).AsImplementedInterfaces().AsSelf();
            builder.RegisterComponent(_obstacleSpawnPointRoot);
	        builder.RegisterComponent(_prefabsStorage);
        
            builder.RegisterInstance(_playerMovementConfig);
            builder.RegisterInstance(_uiConfig);
            builder.RegisterInstance(_gameplayConfig);

            builder.Register<UIManager>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<PlayerControls>(Lifetime.Singleton);
            builder.RegisterEntryPoint<InputService>().AsSelf(); 
            builder.Register<PlayerInput>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterEntryPoint<PlayerJumpSystem>(Lifetime.Scoped)
                .WithParameter(_playerView);
            builder.RegisterEntryPoint<PlayerRotateSystem>(Lifetime.Scoped)
                .WithParameter(_playerView);
                
            builder.Register<ActiveBlocksRegistry>(Lifetime.Scoped);
        	builder.Register<DifficultyState>(Lifetime.Scoped);
        	
        	builder.RegisterEntryPoint<DifficultySystem>(Lifetime.Scoped);
        	
        	builder.Register<LocationBlockPool>(Lifetime.Scoped).AsImplementedInterfaces();
        	
        	builder.RegisterEntryPoint<LocationSpawnSystem>(Lifetime.Scoped)
            	.WithParameter(_obstacleSpawnPointRoot.transform);
            	
            builder.RegisterEntryPoint<LocationMovementSystem>(Lifetime.Scoped);
        }
    }
}
