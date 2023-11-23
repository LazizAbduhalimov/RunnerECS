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
        private const float _touchDeadline = 0.3f;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _filter = world.Filter<PlayerInputComponent>().End();
            _inputPool = world.GetPool<PlayerInputComponent>();
            _transformPool = world.GetPool<TransformComponent>();
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