using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
    [CreateAssetMenu (menuName = "LeoDeg/Managers/DeltaTimeManager")]
    public class DeltaTimeManager : Action
    {
        public Scriptables.FloatScriptable deltaTimeVariable;
        public Scriptables.FloatScriptable fixedDeltaTimeVariable;

        public override void Execute ()
        {
            deltaTimeVariable.value = Time.deltaTime;
            fixedDeltaTimeVariable.value = Time.fixedDeltaTime;
        }
    }
}