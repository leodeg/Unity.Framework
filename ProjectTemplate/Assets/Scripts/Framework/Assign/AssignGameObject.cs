using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
    public class AssignGameObject : MonoBehaviour
    {
        Scriptables.GameObjectScriptable scriptableVariable;

        private void OnEnable ()
        {
            scriptableVariable.value = this.gameObject;
            Destroy (this);
        }
    }
}