using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS {
    sealed class MoveSystem : IEcsInitSystem, IEcsRunSystem {

        private EcsFilter _movables;
        private EcsPool<MoveComponent> _poolMove;
        private EcsPool<RigidbodyComponent> _poolView;
        private EcsPool<PlayerInputComponent> _poolPlayerInput;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _poolMove = world.GetPool<MoveComponent>();
            _poolPlayerInput = world.GetPool<PlayerInputComponent>();
            _poolView = world.GetPool<RigidbodyComponent>();
            _movables = world.Filter<MoveComponent>().Inc<PlayerInputComponent>().Inc<RigidbodyComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity  in _movables)
            {
                Move(entity);
            }
        }

        public void Move(int entity)
        {
            ref var inputComponent = ref _poolPlayerInput.Get(entity);
            ref var moveComponent = ref _poolMove.Get(entity);
            ref var viewComponent = ref _poolView.Get(entity);
            var xVelocity = inputComponent.DirectionX * moveComponent.SideSpeed;
            viewComponent.Rigidbody.velocity = new Vector3(xVelocity, 0f, moveComponent.ForwardSpeed);
        }
    }
}