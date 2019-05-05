using UnityEngine;
using UnityEngine.Events;

namespace LeoDeg.Events
{
    public class ConditionalEvent_BoolVariable : EventExecutionOnMB
    {
        public Scriptables.BoolScriptable targetBool;

        public UnityEvent IfTrue;
        public UnityEvent IfFalse;
        
        /// <summary>
        /// Use this to raise either a true or false event stack based on a bool variable
        /// </summary>
        public override void Raise()
        {
            if(targetBool == null)
            {
                Debug.Log("Bool Variable not assigned on Conditional Event " + this.gameObject.name);
                return;
            }

            if (targetBool.value)
                IfTrue.Invoke();
            else
                IfFalse.Invoke();
        }
    }
}
