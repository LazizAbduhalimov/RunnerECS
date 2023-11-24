using SevenBoldPencil.EasyEvents;
using UnityEngine;

namespace RunnerECS
{
    public struct CreateVFXEvent : IEventReplicant
    {
        public GameObject Prefab;
        public Transform Transform;
        public float LifeTime;
    }
}
