using AB_Utility.FromSceneToEntityConverter;
using UnityEngine;

namespace RunnerECS {
    public class AnimationConverter : ComponentConverter<AnimationComponent> 
    {
        private void OnValidate()
        {
            _component.Animator = GetComponentInChildren<Animator>();
            if (_component.Animator == null)
                throw new System.Exception($"There is no Animator on {name}");
        }
    }
}