using System;
using UnityEngine;

namespace FlappyBird.Rintime.Core.Services.BirdMovment
{
    public interface IMovementController
    {
        Guid AddPermanent(MovementContext context);
        void RemovePermanent(Guid id);
        
        Guid EnqueueOneShot(MovementContext context);
        void CancelOneShot(Guid id);
    }
}
