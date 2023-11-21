using System;
using UnityEngine;

namespace RunnerECS {
    [Serializable]
    public struct FollowComponent {
        public Transform Target;
        public Vector3 Offset;
    }
}