using LeoDeg.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace LeoDeg.Events
{
    public class NumberVariableToNumberVariable_Comparison : EventExecutionOnMB
    {
        public NumberScriptable value1;
        public NumberScriptable value2;

        public UnityEvent IfValue1IsLower;
        public UnityEvent IfValue1IsHigher;

        /// <summary>
        /// Raise true or false event stack based on the comparison of two number variables
        /// </summary>
        public override void Raise()
        {
            if(value1 == null || value2 == null)
            {
                Debug.Log("Number variable comparison doesn't have variables assigned! " + this.gameObject);
                return;
            }

            float v1 = 0;
            float v2 = 0;

            if(value1 is FloatScriptable)
            {
                FloatScriptable f = (FloatScriptable)value1;
                v1 = f.value;
            }

            if(value1 is IntScriptable)
            {
                IntScriptable i = (IntScriptable)value1;
                v1 = i.value;
            }

            if (value2 is FloatScriptable)
            {
                FloatScriptable f = (FloatScriptable)value2;
                v2 = f.value;
            }

            if (value2 is IntScriptable)
            {
                IntScriptable i = (IntScriptable)value2;
                v2 = i.value;
            }

            if(v1 < v2)
            {
                IfValue1IsLower.Invoke();
            }
            else
            {
                IfValue1IsHigher.Invoke();
            }
            
        }

    }
}
