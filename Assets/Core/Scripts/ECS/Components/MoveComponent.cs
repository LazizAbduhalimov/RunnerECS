namespace RunnerECS {
    [System.Serializable]
    public struct MoveComponent {
        public float SideSpeed;
        public float ForwardSpeed;
        [UnityEngine.HideInInspector] public bool IsMoving;
    }
}