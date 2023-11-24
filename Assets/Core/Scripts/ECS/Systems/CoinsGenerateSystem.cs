using Leopotam.EcsLite;
using UnityEngine;

namespace RunnerECS
{
    internal sealed class CoinsGenerateSystem : IEcsInitSystem
    {
        private int _numberOfRepeat = 40;
        private float _instatiateSpace = 2f;
        private Vector3 _offsetByAxis = Vector3.right;
        private Vector3 _generatePoint = new Vector3(2.5f, -4f, 0f);
        private Vector3 _direction;
        private GameObject _prefab;
        private int _rarity;

        public void Init(IEcsSystems systems)
        {
            _direction = Vector3.forward * _instatiateSpace;
            var coinData = systems.GetShared<SharedData>().AllData.CoinData;
            _prefab = coinData.CoinPrefab;
            _rarity = coinData.CoinGenerationRarity;
            Generate();
        }

        private void Generate()
        {
            for (int i = 0; i < _numberOfRepeat; i++) 
            {
                var instatiateRoad = new Vector3(0, 1, 1) + _offsetByAxis * Random.Range(-1, 2);
                if (Random.Range(0, 101) <= _rarity)
                    Object.Instantiate(_prefab, Vector3Multiplication(_generatePoint, instatiateRoad), Quaternion.identity);
                _generatePoint += _direction;
            }
        }

        private Vector3 Vector3Multiplication(Vector3 v1, Vector3 v2) {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }
    }
}