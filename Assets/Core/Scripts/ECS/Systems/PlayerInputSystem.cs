using Leopotam.EcsLite;

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
            foreach (var player in _inputFilter)
            {
                ref var inputComponent = ref _poolInput.Get(player);
                inputComponent.DirectionX = inputComponent.Joystick.Horizontal;
            }
        }
    }
}