using LeoEcsPhysics;
using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS
{
    public sealed class LevelCompletionSystem : TriggerBaseSystem <OnTriggerEnterEvent>
    {
        private GameObject _button;

        public override void Init(IEcsSystems systems)
        {
            base.Init(systems);
            _button = GameObject.FindObjectOfType<RestartButtonTag>(true).gameObject;
        }

        protected override void CheckTrigger(OnTriggerEnterEvent eventData, SharedData sharedData)
        {
            if (eventData.collider.TryGetComponent<FinishPointTag>(out var point))
            {
                _button.SetActive(true);
            }
        }

        public static void Restart()
        {
            LevelLoader.Instance.Restart();
        }
    }
}