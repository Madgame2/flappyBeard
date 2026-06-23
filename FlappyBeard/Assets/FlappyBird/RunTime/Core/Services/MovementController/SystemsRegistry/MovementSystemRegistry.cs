using System;
using System.Collections.Generic;
using System.Linq;
using FlappyBird.Rintime.Core.Services.BirdMovment.Meta;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.SystemsRegistry
{
    public class MovementSystemRegistry
    {
        private readonly Dictionary<MovementType, IMovementSystem> _systems;

        // VContainer автоматически сожмет все IMovementSystem в этот список
        public MovementSystemRegistry(IReadOnlyList<IMovementSystem> systems)
        {
            _systems = systems.ToDictionary(s => s.Type);
        }

        public IMovementSystem GetSystem(MovementType type)
        {
            if (_systems.TryGetValue(type, out var system))
            {
                return system;
            }
            throw new Exception($"Система движения для типа {type} не найдена!");
        }
    }
}