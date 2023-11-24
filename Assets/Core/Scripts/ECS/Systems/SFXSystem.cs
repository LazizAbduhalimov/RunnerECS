using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS
{
    internal sealed class SFXSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var shared = systems.GetShared<SharedData>();
            var events = shared.EventsBus;
            var filter = events.GetEventBodies<CreateSFXEvent>(out var creationSFXPool);
            foreach (var entity in filter)
            {
                ref var eventBody = ref creationSFXPool.Get(entity);
                ref var prefab = ref eventBody.SoundObject;
                var transform = eventBody.Transform;
                var effect = Object.Instantiate(prefab);
                Object.Destroy(effect, 2);
            }
        }
    }
}