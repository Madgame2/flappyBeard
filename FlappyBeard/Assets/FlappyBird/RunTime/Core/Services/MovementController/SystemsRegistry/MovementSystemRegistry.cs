using System;
using System.Collections.Generic;
using System.Linq;
using FlappyBird.Rintime.Core.Services.BirdMovment.Meta;

namespace FlappyBird.Rintime.Core.Services.BirdMovment.SystemsRegistry
{
    public class MovementSystemRegistry
    {
        private readonly Dictionary<MovementType, IMovementSystem> _systemsByType;

        public MovementSystemRegistry(IReadOnlyList<IMovementSystem> movementSystems)
        {
            _systemsByType = movementSystems.ToDictionary(system => system.Type);
        }

        public IMovementSystem GetSystem(MovementType type)
        {
            if (_systemsByType.TryGetValue(type, out var system))
            {
                return system;
            }
            
            throw new Exception($"Система движения для типа {type} не найдена!");
        }
    }
}