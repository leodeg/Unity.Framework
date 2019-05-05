using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.StateActions
{
    public class StateMachine : MonoBehaviour
    {
        State currentState;

        private void OnEnable ()
        {
            currentState.OnEnable (this);
        }

        private void OnDisable ()
        {
            currentState.OnDisable (this);
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
    }
}