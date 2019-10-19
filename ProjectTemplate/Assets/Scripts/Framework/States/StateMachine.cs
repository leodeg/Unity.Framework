using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Framework
{
    public class StateMachine : MonoBehaviour
    {
        protected State currentState;

        public void SetCurrentState (State state)
        {
            currentState = state;
        }

        public State GetCurrentState ()
        {
            return currentState;
        }

        private void Enter ()
        {
            currentState.OnEnter (this);
        }

        private void Exit ()
        {
            currentState.OnExit (this);
        }

        private void Awake ()
        {
            currentState.OnAwake (this);
        }

        private void Start ()
        {
            currentState.OnStart (this);
        }

        private void FixedUpdate ()
        {
            currentState.OnFixed (this);
        }

        private void Update ()
        {
            currentState.OnUpdate (this);
        }

        private void LateUpdate ()
        {
            currentState.OnLateUpdate (this);
        }
    }
}