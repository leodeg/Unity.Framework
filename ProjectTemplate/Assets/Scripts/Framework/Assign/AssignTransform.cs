using UnityEngine;
using System.Collections;

namespace LeoDeg.Assign
{
    public class AssignTransform : MonoBehaviour
    {
        Scriptables.TransformScriptable scriptableVariable;

        private void OnEnable ()
        {
            scriptableVariable.value = this.transform;
            Destroy (this);
        }
    }
}