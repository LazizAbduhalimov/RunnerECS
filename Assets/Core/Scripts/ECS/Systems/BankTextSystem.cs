using Leopotam.EcsLite;

namespace RunnerECS
{
    internal sealed class BankTextSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<BankTextComponent> _pool; 
        
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _filter = world.GetFilterAndPool(out _pool);
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ResetText(entity);
            }
        }

        private void ResetText(int entity)
        {
            ref var textComponent = ref _pool.Get(entity);
            textComponent.Text.text = Bank.Instance.Coins.ToString();
        }
    }
}