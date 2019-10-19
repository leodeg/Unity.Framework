using System.Collections;
using UnityEngine;

namespace LeoDeg.Framework.Scriptables
{
	[CreateAssetMenu(menuName = "LeoDeg/Variables/StateScriptable")]
	public class StateScriptable : ScriptableObject
	{
		public LeoDeg.Framework.State value;
	}
}