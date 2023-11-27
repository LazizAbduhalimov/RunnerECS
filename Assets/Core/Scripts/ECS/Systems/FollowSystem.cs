using Leopotam.EcsLite;

namespace RunnerECS {
    sealed class FollowSystem : IEcsInitSystem, IEcsRunSystem {
        private EcsFilter _followers;
        private EcsPool<FollowComponent> _followersPool;
        private EcsPool<TransformComponent> _transformPool; 

        public void Init (IEcsSystems systems) {
            var world = systems.GetWorld ();
            _followers = world.GetFilterAndPools(out _followersPool, out _transformPool);
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _followers)
            {
                Follow(entity);
            }
        }

        private void Follow(int entity)
        {
            ref var followComponent = ref _followersPool.Get(entity);
            ref var transformComponent = ref _transformPool.Get(entity);
            transformComponent.Transform.position = followComponent.Target.position + followComponent.Offset;
        }
    }
}