using UnityEngine;

namespace RunnerECS
{
    [CreateAssetMenu(menuName = "ScriptableObjects/AllDataLinkContainer")]
    public class AllDataLinkContainer : ScriptableObject
    {
        public CoinData CoinData;
        public PlayerStats PlayerStats;

        public static AllDataLinkContainer GetAllDataLinks(string dataName)
        {
            return Resources.Load($"Data/{dataName}") as AllDataLinkContainer;
        }
    }
}
