﻿using Leopotam.EcsLite;

namespace RunnerECS
{
    public abstract class TriggerBaseSystem <T> : IEcsInitSystem, IEcsRunSystem, IEcsPostRunSystem where T: struct
    {
        private EcsFilter _filter;
        private EcsPool<T> _pool;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _filter = world.Filter<T>().End();
            _pool = world.GetPool<T>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var eventData = ref _pool.Get(entity);
                CheckTrigger(eventData);
            }
        }

        public void PostRun(IEcsSystems systems)
        {
            foreach (var entity in _filter)
                _pool.Del(entity);
        }

        protected abstract void CheckTrigger(T eventData);
    }
}