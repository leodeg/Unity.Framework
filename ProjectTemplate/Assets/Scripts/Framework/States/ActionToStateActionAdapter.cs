using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
    [CreateAssetMenu (menuName = "LeoDeg/States/ActionToStateActionAdapter")]
    public class ActionToStateActionAdapter : StateAction
    {
        public Actions.Action action;

        public override void Execute (StateMachine state)
        {
            action.Execute ();
        }
    }
}