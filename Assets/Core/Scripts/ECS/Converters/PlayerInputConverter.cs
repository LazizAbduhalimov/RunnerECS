using AB_Utility.FromSceneToEntityConverter;
using UnityEngine;

namespace RunnerECS {
    [SelectionBase]
    public class PlayerInputConverter : ComponentConverter<PlayerInputComponent> { }
}