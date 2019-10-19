using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
	[System.Serializable]
	[CreateAssetMenu (menuName = "LeoDeg/Inventory/Item Object")]
	public class InventoryItem : Item
	{
		public GameObject prefab;
		public ItemInformation ItemInformation;
	}
}