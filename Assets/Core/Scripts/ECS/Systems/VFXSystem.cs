using Leopotam.EcsLite;
using SevenBoldPencil.EasyEvents;
using UnityEngine;

namespace RunnerECS
{
    internal sealed class VFXSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<CreateVFXEvent> _pool;

        public void Init(IEcsSystems systems)
        {
            _filter = systems.GetShared<SharedData>().EventsBus.GetEventBodies(out _pool);
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var eventBody = ref _pool.Get(entity);
                var effect = Object.Instantiate(eventBody.Prefab, eventBody.Transform.position, Quaternion.identity);
                Object.Destroy(effect, eventBody.LifeTime);
            }
        }
    }
}