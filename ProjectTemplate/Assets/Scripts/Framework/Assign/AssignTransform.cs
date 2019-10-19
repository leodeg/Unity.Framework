using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
	public class AssignTransform : MonoBehaviour
	{
		[SerializeField]
		private Scriptables.TransformScriptable scriptableVariable;

		private void OnEnable ()
		{
			if (scriptableVariable != null)
				scriptableVariable.value = this.transform;
			Destroy (this);
		}
	}
}