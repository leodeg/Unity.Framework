using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
	[System.Serializable]
	public abstract class Item : ScriptableObject
	{
		public string name;
		public GameObject prefab;
	}
}