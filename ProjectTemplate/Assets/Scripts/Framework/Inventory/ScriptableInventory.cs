using UnityEngine;
using System.Collections;
using System;

namespace LeoDeg.Framework
{
	[System.Serializable]
	[CreateAssetMenu (menuName = "LeoDeg/Inventory/ScriptableInventory")]
	public class ScriptableInventory : ScriptableObject
	{
		public Inventory inventory;
	}
}