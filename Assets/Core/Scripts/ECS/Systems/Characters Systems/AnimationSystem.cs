using Client;
using Leopotam.EcsLite;
using SevenBoldPencil.EasyEvents;

namespace RunnerECS
{
    public class AnimationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<AnimationComponent> _animationPool;
        private EcsPool<MoveComponent> _movePool;
        private EventsBus _eventsBus;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _filter = world.GetFilterAndPools(out _animationPool, out _movePool);
            _eventsBus = systems.GetShared<SharedData>().EventsBus;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var animationComponent = ref _animationPool.Get(entity);
                ref var moveComponent = ref _movePool.Get(entity);

                animationComponent.Animator.SetBool("IsMoving", moveComponent.IsMoving);
            }
            
            var onFinishEventsfilter = _eventsBus.GetEventBodies<OnFinishEvent>(out _);
            foreach (var e in onFinishEventsfilter)
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




