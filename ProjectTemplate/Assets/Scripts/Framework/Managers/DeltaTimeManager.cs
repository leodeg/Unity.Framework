using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
    [CreateAssetMenu (menuName = "LeoDeg/Managers/DeltaTimeManager")]
    public class DeltaTimeManager : Action
    {
		[SerializeField]
        private Scriptables.FloatScriptable deltaTimeVariable;

		[SerializeField]
		private Scriptables.FloatScriptable fixedDeltaTimeVariable;

        public override void Execute ()
        {
            deltaTimeVariable.value = Time.deltaTime;
            fixedDeltaTimeVariable.value = Time.fixedDeltaTime;
        }
	}
}