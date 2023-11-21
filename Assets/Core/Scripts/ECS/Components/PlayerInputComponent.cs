using System;
using UnityEngine;

namespace RunnerECS {
    [Serializable]
    public struct PlayerInputComponent {
        [HideInInspector] public float DirectionX;
        public Joystick Joystick;
    }
}