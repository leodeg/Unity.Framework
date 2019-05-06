using UnityEngine;
using System.Collections;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/StateBooleanSwitcher")]
    public class StateBooleanSwitcher : StateAction
    {
        public Scriptables.BoolScriptable boolScriptable;
        public State onTrue;
        public State onFalse;

        public override void Execute (StateMachine state)
        {
            if (boolScriptable)
            {
                if (onTrue != null && state.GetState () != onTrue)
                    state.SetState (onTrue);
                else Debug.LogWarning ("StateBooleanSwitcher::Warning::OnTrue state is not assign!");
            }
            else
            {
                if (onFalse != null && state.GetState () != onFalse)
                    state.SetState (onFalse);
                else Debug.LogWarning ("StateBooleanSwitcher::Warning::OnTrue state is not assign!");
            }
        }
    }
}