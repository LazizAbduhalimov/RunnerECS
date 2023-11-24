using Client;
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

            var shared = systems.GetShared<SharedData>();
            var events = shared.EventsBus;
            var filter = events.GetEventBodies<OnFinishEvent>(out var pool);
            foreach (var e in filter)
            {
                foreach (var entity in _filter)
                {
                    ref var animationComponent = ref _animationPool.Get(entity);
                    _movePool.Del(entity);
                    animationComponent.Animator.SetBool("Win", true);

                }
            }
        }
    }

}
