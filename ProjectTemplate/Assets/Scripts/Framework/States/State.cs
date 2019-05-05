using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/State")]
    public class State : ScriptableObject
    {
        public StateAction[] onAwake;
        public StateAction[] onStart;
        public StateAction[] onFixed;
        public StateAction[] onUpdate;
        public StateAction[] onEnter;
        public StateAction[] onExit;

        public void OnAwake (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onAwake);
        }

        public void OnStart (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onStart);
        }

        public void OnFixed (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onFixed);
        }

        public void OnUpdate (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onUpdate);
        }

        public void OnEnable (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onEnter);
        }

        public void OnDisable (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onExit);
        }

        public void ExecuteActions (StateMachine state, StateAction[] actions)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Execute (state);
            }
        }
    }
}