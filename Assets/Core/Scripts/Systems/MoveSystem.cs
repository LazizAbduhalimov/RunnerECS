using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS {
    sealed class MoveSystem : IEcsInitSystem, IEcsRunSystem {

        private EcsFilter _movables;
        private EcsPool<MoveComponent> _poolMove;
        private EcsPool<ViewComponent> _poolView;
        private EcsPool<PlayerInputComponent> _poolPlayerInput;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _poolMove = world.GetPool<MoveComponent>();
            _poolPlayerInput = world.GetPool<PlayerInputComponent>();
            _poolView = world.GetPool<ViewComponent>();
            _movables = world.Filter<MoveComponent>().Inc<PlayerInputComponent>().Inc<ViewComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity  in _movables)
            {
                var inputComponent = _poolPlayerInput.Get(entity);
                var moveComponent = _poolMove.Get(entity);
                var viewComponent = _poolView.Get(entity);
                Debug.Log(moveComponent.Speed);
                viewComponent.Rigidbody.velocity = inputComponent.Direction * moveComponent.Speed;
            }
        }
    }
}