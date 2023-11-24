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
            events.NewEvent<CreateVFXEvent>() = new CreateVFXEvent { 
                Prefab = sharedData.AllData.CoinData.CoinSFXData, 
                Transform = coin.transform,
                LifeTime = 2f
            };
            events.NewEvent<CreateVFXEvent>() = new CreateVFXEvent
            {
                Prefab = sharedData.AllData.CoinData.CoinVFXData,
                Transform = coin.transform,
                LifeTime = 2f
            };

            Bank.Instance.Add(coin, coin.Number);
            Object.Destroy(coin.gameObject);
        }
    }
}