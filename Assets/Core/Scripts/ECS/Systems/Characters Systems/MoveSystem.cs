using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS {
    sealed class MoveSystem : IEcsInitSystem, IEcsRunSystem {

        private EcsFilter _movables;
        private EcsPool<MoveComponent> _poolMove;
        private EcsPool<RigidbodyComponent> _poolRigidbody;
        private EcsPool<PlayerInputComponent> _poolPlayerInput;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _movables = world.GetFilterAndPools(out _poolMove, out _poolPlayerInput, out _poolRigidbody);
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
            ref var rigidbodyComponent = ref _poolRigidbody.Get(entity);
            var xVelocity = inputComponent.DirectionX * moveComponent.SideSpeed;
            rigidbodyComponent.Rigidbody.velocity = new Vector3(xVelocity, 0f, moveComponent.ForwardSpeed);
            moveComponent.IsMoving = rigidbodyComponent.Rigidbody.velocity.magnitude > 0;
        }
    }
}