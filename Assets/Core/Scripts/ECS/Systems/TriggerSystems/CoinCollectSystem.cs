using UnityEngine;
using LeoEcsPhysics;

namespace RunnerECS
{
    public sealed class CoinCollectSystem : TriggerBaseSystem<OnTriggerEnterEvent> 
    {
        protected override void CheckTrigger(OnTriggerEnterEvent eventData, SharedData sharedData)
        {
            if (eventData.collider.TryGetComponent<CoinTag>(out var coin))
            {
                CollectAndDestroy(coin, sharedData);
            }
        }

        private void CollectAndDestroy(CoinTag coin, SharedData sharedData)
        {
            var events = sharedData.EventsBus;
            events.NewEvent<CreateSFXEvent>() = new CreateSFXEvent { 
                SoundObject = sharedData.AllData.CoinFXData.Prefab, 
                Transform = coin.transform 
            };
            Bank.Instance.Add(coin, coin.Number);
            Object.Destroy(coin.gameObject);
        }
    }
}