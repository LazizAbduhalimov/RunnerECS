using Leopotam.EcsLite;
using Leopotam.EcsLite.Unity.Ugui;

namespace RunnerECS
{
    public class UIEventsSystem : IEcsInitSystem, IEcsRunSystem
    {
        EcsPool<EcsUguiClickEvent> _clickEventsPool;
        EcsFilter _clickEvents;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _clickEvents = world.GetFilterAndPool(out _clickEventsPool);
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
