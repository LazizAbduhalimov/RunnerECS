using UnityEngine;
using LeoEcsPhysics;

namespace RunnerECS
{
    public sealed class CoinCollectSystem : TriggerBaseSystem<OnTriggerEnterEvent> 
    {

        protected override void CheckTrigger(OnTriggerEnterEvent eventData)
        {
            if (eventData.collider.TryGetComponent<CoinTag>(out var coin))
                CollectAndDestroy(coin);
        }

        private void CollectAndDestroy(CoinTag coin)
        {
            Bank.Instance.Add(coin, coin.Number);
            Object.Destroy(coin.gameObject);
        }
    }
}