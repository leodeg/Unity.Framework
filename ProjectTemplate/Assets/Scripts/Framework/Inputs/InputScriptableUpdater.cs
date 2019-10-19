using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
    [CreateAssetMenu (menuName = "LeoDeg/Inputs/InputUpdater")]
    public class InputScriptableUpdater : Action
    {
        public Action[] inputs;

        public override void Execute ()
        {
            if (inputs == null) return;

            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i].Execute ();
            }
        }
    }
}