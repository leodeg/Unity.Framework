using UnityEngine;
using System.Collections;
using System;

namespace LeoDeg.Framework
{
	[System.Serializable]
	[CreateAssetMenu (menuName = "LeoDeg/Inventory/Inventory")]
	public class Inventory : ScriptableObject
	{
		[SerializeField] private ItemInstance[] inventory;

		public bool SlotEmpty (int index)
		{
			if (inventory[index] == null || inventory[index].item == null)
				return true;
			return false;
		}

		public ItemInstance GetItem (int index)
		{
			if (SlotEmpty (index))
				return null;
			return inventory[index];
		}

		public bool GetItem (int index, out ItemInstance item)
		{
			if (SlotEmpty (index))
			{
				item = null;
				return false;
			}

			item = inventory[index];
			return true;
		}

		public ItemInstance GetItem (string itemName)
		{
			for (int i = 0; i < inventory.Length; i++)
			{
				if (inventory[i].item.name == itemName)
					return inventory[i];
			}

			return null;
		}

		public bool GetItem (string itemName, out ItemInstance item)
		{
			for (int i = 0; i < inventory.Length; i++)
			{
				if (inventory[i].item.name == itemName)
				{
					item = inventory[i];
					return true;
				}
			}

			item = null;
			return false;
		}

		public int InsertItem (ItemInstance item)
		{
			for (int slotIndex = 0; slotIndex < inventory.Length; slotIndex++)
			{
				if (SlotEmpty (slotIndex))
				{
					inventory[slotIndex] = item;
					return slotIndex;
				}
			}
			return -1;
		}

		public bool RemoveItem (int index)
		{
			if (SlotEmpty (index))
				return false;

			inventory[index] = null;
			return true;
		}

		public void SaveInventory ()
		{

			throw new NotImplementedException ();
		}
	}
}