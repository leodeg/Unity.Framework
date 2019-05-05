using UnityEngine.UI;
using LeoDeg.Scriptables;

namespace LeoDeg.UI
{
    public class UpdateSlider : UIPropertyUpdater
    {
        public NumberScriptable targetVariable;
        public Slider targetSlider;

        public override void Raise()
        {
            if(targetVariable is FloatScriptable)
            {
                FloatScriptable f = (FloatScriptable)targetVariable;
                targetSlider.value = f.value;
                return;
            }

            if(targetVariable is IntScriptable)
            {
                IntScriptable i = (IntScriptable)targetVariable;
                targetSlider.value = i.value;
            }
        }
    }
}
