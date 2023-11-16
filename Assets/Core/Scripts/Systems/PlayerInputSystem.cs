using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS {
    sealed class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem {
        private EcsFilter _inputFilter;
        private EcsPool<PlayerInputComponent> _poolInput;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _inputFilter = world.Filter<PlayerInputComponent>().End();
            _poolInput = world.GetPool<PlayerInputComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            foreach (var player in _inputFilter)
            {
                var inputComponent = _poolInput.Get(player);
                inputComponent.Direction = direction;
            }
        }
    }
}