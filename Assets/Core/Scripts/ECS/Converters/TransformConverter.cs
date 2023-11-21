using AB_Utility.FromSceneToEntityConverter;

namespace RunnerECS {
    public class TransformConverter : ComponentConverter<TransformComponent>
    {
        private void OnValidate()
        {
            _component.Transform = GetComponent<UnityEngine.Transform>();
        }
    }
}