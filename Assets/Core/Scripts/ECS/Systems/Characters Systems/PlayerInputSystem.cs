using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS {
    sealed class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem {
        private EcsFilter _inputFilter;
        private EcsPool<PlayerInputComponent> _poolInput;
        private bool _isInitialized = false;
        
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _inputFilter = world.GetFilterAndPool(out _poolInput);
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var player in _inputFilter)
            {
                ref var inputComponent = ref _poolInput.Get(player);
                inputComponent.DirectionX = inputComponent.Joystick.Horizontal;

                if (!_isInitialized && Mathf.Abs(inputComponent.DirectionX) > 0)
                {
                    _isInitialized = true;
                    AddMoveComponent(systems, player);
                }
            }
        }

        private static void AddMoveComponent(IEcsSystems systems, int player)
        {
            var movePool = systems.GetWorld().GetPool<MoveComponent>();
            ref var moveComponent = ref movePool.Add(player);
            var playerStats = systems.GetShared<SharedData>().AllData.PlayerStats;
            moveComponent.ForwardSpeed = playerStats.ForwardSpeed;
            moveComponent.SideSpeed = playerStats.SideSpeed;
        }
    }
}