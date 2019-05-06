using UnityEngine;
using System.Collections;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/StateConditionSwitcher")]
    public class StateConditionSwitcher : StateAction
    {
        public Conditions.Condition condition;
        public State onTrue;
        public State onFalse;

        public override void Execute (StateMachine state)
        {
            if (condition.CheckCondition (state))
            {
                if (onTrue != null && state.GetState () != onTrue)
                    state.SetState (onTrue);
                else Debug.LogWarning ("StateConditionSwitcher::Warning::OnTrue state is not assign!");
            }
            else
            {
                if (onFalse != null && state.GetState () != onFalse)
                    state.SetState (onFalse);
                else Debug.LogWarning ("StateConditionSwitcher::Warning::OnTrue state is not assign!");
            }
        }
    }
}