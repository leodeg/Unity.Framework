using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
    public abstract class Condition : ScriptableObject
    {
        public string description;

        public abstract bool CheckCondition (StateMachine state);
    }
}