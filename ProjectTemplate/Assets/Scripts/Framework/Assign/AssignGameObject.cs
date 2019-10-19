using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
	public class AssignGameObject : MonoBehaviour
	{
		[SerializeField]
		private Scriptables.GameObjectScriptable scriptableVariable = default;

		private void OnEnable ()
		{
			if (scriptableVariable != null)
				scriptableVariable.value = this.gameObject;
			Destroy (this);
		}
	}
}