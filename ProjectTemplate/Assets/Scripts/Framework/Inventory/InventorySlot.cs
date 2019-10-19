using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LeoDeg.Framework
{
	[System.Serializable]
	public class InventorySlot
	{
		public InventoryItem item;
		[SerializeField] private int quantity;
		[SerializeField] private int maxQuantity;
	}
}