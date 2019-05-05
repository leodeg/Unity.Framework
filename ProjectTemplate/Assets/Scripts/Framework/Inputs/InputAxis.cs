using UnityEngine;
using System.Collections;

namespace LeoDeg.Inputs
{
    [CreateAssetMenu (menuName = "LeoDeg/Inputs/Axis")]
    public class InputAxis : Actions.Action
    {
        public string axisName;
        public float value;

        public override void Execute ()
        {
            value = Input.GetAxis (axisName);
        }
    }
}