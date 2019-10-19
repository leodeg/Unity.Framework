using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Framework
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Execute ();
    }
}