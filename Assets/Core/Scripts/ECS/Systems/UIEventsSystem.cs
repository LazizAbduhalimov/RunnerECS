using Leopotam.EcsLite;
using Leopotam.EcsLite.Unity.Ugui;
using UnityEngine;

namespace RunnerECS
{
    public class UIEventsSystem : IEcsInitSystem, IEcsRunSystem
    {
        EcsPool<EcsUguiClickEvent> _clickEventsPool;
        EcsFilter _clickEvents;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _clickEventsPool = world.GetPool<EcsUguiClickEvent>();
            _clickEvents = world.Filter<EcsUguiClickEvent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _clickEvents)
            {
                ref EcsUguiClickEvent data = ref _clickEventsPool.Get(entity);
                if (data.WidgetName == "next")
                {
                    LevelCompletionSystem.Restart();
                }
            }
        }
    }
}
