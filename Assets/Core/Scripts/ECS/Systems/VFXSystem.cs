using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS
{
    internal sealed class VFXSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var events = systems.GetShared<SharedData>().EventsBus;
            var filter = events.GetEventBodies<CreateVFXEvent>(out var creationSFXPool);
            foreach (var entity in filter)
            {
                ref var eventBody = ref creationSFXPool.Get(entity);
                var effect = Object.Instantiate(eventBody.Prefab, eventBody.Transform.position, Quaternion.identity);
                Object.Destroy(effect, eventBody.LifeTime);
            }
        }
    }
}