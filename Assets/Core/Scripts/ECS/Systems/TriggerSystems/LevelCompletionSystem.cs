using Client;
using LeoEcsPhysics;
using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS
{
    public sealed class LevelCompletionSystem : TriggerBaseSystem <OnTriggerEnterEvent>
    { 
        private GameObject _button;
        private CompletionEffectTag[] _effects;

        public override void Init(IEcsSystems systems)
        {
            base.Init(systems);
            //? How to pass link without searching in hierarchy
            _button = Object.FindObjectOfType<RestartButtonTag>(true).gameObject;
            _effects = Object.FindObjectsOfType<CompletionEffectTag>(true);
        }

        protected override void CheckTrigger(OnTriggerEnterEvent eventData, SharedData sharedData)
        {
            if (eventData.collider.TryGetComponent<FinishPointTag>(out _))
            {
                var events = sharedData.EventsBus;
                events.NewEvent<OnFinishEvent>() = new OnFinishEvent();
                EnableNextButton();
                PlayEffects();
            }
        }

        public static void Restart()
        {
            LevelLoader.Instance.Restart();
        }

        private void PlayEffects()
        {
            foreach (var effect in _effects)
            {
                effect.gameObject.SetActive(true);
            }
        }

        private void EnableNextButton()
        {
            _button.SetActive(true);
        }
    }
}