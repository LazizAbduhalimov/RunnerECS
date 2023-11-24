using SevenBoldPencil.EasyEvents;
using UnityEngine;

namespace RunnerECS
{
    public struct CreateSFXEvent : IEventReplicant
    {
        public GameObject SoundObject;
        public Transform Transform; 
    }
}
