using System;

namespace RunnerECS {
    [Serializable]
    public struct MoveComponent {
        public float SideSpeed;
        public float ForwardSpeed;
    }
}