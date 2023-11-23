using Leopotam.EcsLite;

namespace RunnerECS
{
    public class AnimationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<AnimationComponent> _animationPool;
        private EcsPool<MoveComponent> _movePool;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _filter = world.Filter<AnimationComponent>().Inc<MoveComponent>().End();
            _animationPool = world.GetPool<AnimationComponent>();
            _movePool = world.GetPool<MoveComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var animationComponent = ref _animationPool.Get(entity);
                ref var moveComponent = ref _movePool.Get(entity);

                animationComponent.Animator.SetBool("IsMoving", moveComponent.IsMoving);
            }
        }
    }

}
