using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
	/// <summary>
	/// Template for future items.
	/// </summary>
	[System.Serializable]
	public class ItemInstance : MonoBehaviour
	{
		public Item item;

		public ItemInstance (Item item)
		{
			this.item = item;
		}
	}
}