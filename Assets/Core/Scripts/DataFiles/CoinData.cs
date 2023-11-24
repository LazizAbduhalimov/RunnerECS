using UnityEngine;

namespace RunnerECS
{
    [CreateAssetMenu(menuName = ("ScriptableObjects/CoinData"))]
    public class CoinData : ScriptableObject
    {
        public GameObject CoinSFXData;
        public GameObject CoinVFXData;
        public GameObject CoinPrefab;
        [Range(0, 100)]
        public int CoinGenerationRarity = 50;
    }
}
