using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS
{
    internal sealed class RotationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<PlayerInputComponent> _inputPool;
        private EcsPool<TransformComponent> _transformPool;

        private const float _maxAngle = 30f;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _filter = world.GetFilterAndPools(out _inputPool, out _transformPool);
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var inputComponent = ref _inputPool.Get(entity);
                ref var transformComponent = ref _transformPool.Get(entity);

                var angle = _maxAngle * inputComponent.DirectionX;
                transformComponent.Transform.rotation = Quaternion.Euler(0, angle, 0);
            }
        }
    }
}