using System;
using System.Collections;
using UnityEngine;

namespace LeoDeg.Framework
{
	[System.Serializable]
	public class Inventory
	{
		[SerializeField] private InventorySlot[] slots;

		public int Capacity { get; private set; }

		public bool SlotEmpty (int index)
		{
			if (slots[index] == null || slots[index].item == null)
				return true;
			return false;
		}

		public InventoryItem GetItem (int index)
		{
			if (SlotEmpty (index))
				return null;
			return slots[index].item;
		}

		public bool GetItem (int index, out InventoryItem item)
		{
			if (SlotEmpty (index))
			{
				item = null;
				return false;
			}

			item = slots[index].item;
			return true;
		}

		public InventoryItem GetItem (string itemName)
		{
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[i].item.itemName == itemName)
					return slots[i].item;
			}

			return null;
		}

		public bool GetItem (string itemName, out InventoryItem item)
		{
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[i].item.itemName == itemName)
				{
					item = slots[i].item;
					return true;
				}
			}

			item = null;
			return false;
		}

		public int InsertItem (InventoryItem item)
		{
			for (int slotIndex = 0; slotIndex < slots.Length; slotIndex++)
			{
				if (SlotEmpty (slotIndex))
				{
					slots[slotIndex].item = item;
					++Capacity;
					return slotIndex;
				}
			}
			return -1;
		}

		public bool RemoveItem (int index)
		{
			if (SlotEmpty (index))
				return false;

			slots[index] = null;
			--Capacity;
			return true;
		}

		public void SaveInventory ()
		{
			throw new NotImplementedException ();
		}
	}
}