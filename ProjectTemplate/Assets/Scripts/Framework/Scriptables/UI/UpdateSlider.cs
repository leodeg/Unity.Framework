using UnityEngine.UI;
using LeoDeg.Framework.Scriptables;

namespace LeoDeg.Framework.UI
{
    public class UpdateSlider : UIPropertyUpdater
    {
        public NumberScriptable targetVariable;
        public Slider targetSlider;

        public override void Raise()
        {
            if(targetVariable is FloatScriptable)
            {
                FloatScriptable floatVariable = (FloatScriptable)targetVariable;
                targetSlider.value = floatVariable.value;
                return;
            }

            if(targetVariable is IntScriptable)
            {
                IntScriptable integerVariable = (IntScriptable)targetVariable;
                targetSlider.value = integerVariable.value;
            }
        }
    }
}
