using UnityEngine;

namespace RunnerECS
{
    [CreateAssetMenu(menuName = ("ScriptableObjects/PlayerStats"))]
    public class PlayerStats : ScriptableObject
    {
        public float SideSpeed;
        public float ForwardSpeed;
    }
}
