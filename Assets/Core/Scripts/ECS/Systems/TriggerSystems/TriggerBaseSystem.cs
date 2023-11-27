using Leopotam.EcsLite;

namespace RunnerECS
{
    public abstract class TriggerBaseSystem <T> : IEcsInitSystem, IEcsRunSystem, IEcsPostRunSystem where T: struct
    {
        private EcsFilter _filter;
        private EcsPool<T> _pool;

        public virtual void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _filter = world.GetFilterAndPool(out _pool);
        }

        public virtual void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var eventData = ref _pool.Get(entity);
                CheckTrigger(eventData, systems.GetShared<SharedData>());
            }
        }

        public void PostRun(IEcsSystems systems)
        {
            foreach (var entity in _filter)
                _pool.Del(entity);
        }

        protected abstract void CheckTrigger(T eventData, SharedData sharedData);
    }
}