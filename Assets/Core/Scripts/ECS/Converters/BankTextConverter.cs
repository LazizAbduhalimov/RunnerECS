using AB_Utility.FromSceneToEntityConverter;
using UnityEngine.UI;

namespace RunnerECS {
    public class BankTextConverter : ComponentConverter<BankTextComponent> 
    {
        private void OnValidate()
        {
            _component.Text = GetComponent<Text>();
            if (_component.Text == null)
                throw new System.Exception($"There is no Text on {name}");
        }
    }
}