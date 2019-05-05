using UnityEngine;
using System.Collections;

namespace LeoDeg.Assign
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