using UnityEngine;

namespace LeoDeg.Framework
{
    public abstract class StateAction : ScriptableObject
    {
        public abstract void Execute (StateMachine state);
    }
}