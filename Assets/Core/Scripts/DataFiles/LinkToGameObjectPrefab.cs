using UnityEngine;

namespace RunnerECS
{
    [CreateAssetMenu(menuName = ("ScriptableObjects/LinkToGameObjectPrefab"))]
    public class LinkToGameObjectPrefab : ScriptableObject
    {
        public GameObject Prefab;
    }
}
