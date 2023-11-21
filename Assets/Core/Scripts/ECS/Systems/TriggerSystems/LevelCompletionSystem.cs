using LeoEcsPhysics;

namespace RunnerECS
{
    public sealed class LevelCompletionSystem : TriggerBaseSystem <OnTriggerEnterEvent>
    {

        protected override void CheckTrigger(OnTriggerEnterEvent eventData)
        {
            if (eventData.collider.TryGetComponent<FinishPointTag>(out var point))
            {
                LevelLoader.Instance.Restart();
            }
        }
    }
}