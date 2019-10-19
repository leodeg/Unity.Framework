using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Framework
{
	[CreateAssetMenu (menuName = "LeoDeg/Managers/GameObjectPoolManager")]
	public class GameObjectPoolManager : ScriptableObject
	{
		[SerializeField]
		private List<GameObjectPool> gameObjectPools = new List<GameObjectPool> ();

		// String - is a prefab name, integer - is an id of the object.
		private Dictionary<string, int> gameObjectPoolDictionary = new Dictionary<string, int> ();
		private GameObject poolParent;

		public void Initialize ()
		{
			if (poolParent != null)
				Destroy (poolParent);

			poolParent = new GameObject ();
			poolParent.name = "GameObjectsPoolManager";
			gameObjectPoolDictionary.Clear ();

			InitializeGameObjectPoolDictionary ();
		}

		private void InitializeGameObjectPoolDictionary ()
		{
			for (int currentID = 0; currentID < gameObjectPools.Count; currentID++)
			{
				if (gameObjectPools[currentID].maxAmount < 1)
					gameObjectPools[currentID].maxAmount = 1;

				gameObjectPools[currentID].currentIndex = 0;
				gameObjectPools[currentID].createdObjects.Clear ();

				if (GameObjectIsValid (currentID))
					gameObjectPoolDictionary.Add (gameObjectPools[currentID].prefabName, currentID);
			}
		}

		private bool GameObjectIsValid (int currentObjectID)
		{
			if (string.IsNullOrEmpty (gameObjectPools[currentObjectID].prefabName))
			{
				Debug.LogWarning ("GameObjectPoolManager::Warning:: Entry with prefab [" + gameObjectPools[currentObjectID].prefab.name + "] has an empty prefab name.");
				return false;
			}

			if (gameObjectPoolDictionary.ContainsKey (gameObjectPools[currentObjectID].prefabName))
			{
				Debug.LogWarning ("GameObjectPoolManager::Warning:: Entry with id [" + gameObjectPools[currentObjectID].prefabName + "] is a duplicate.");
				return false;
			}

			return true;
		}

		public GameObject GetPoolObject (string name)
		{
			int currentPoolID;
			if (gameObjectPoolDictionary.TryGetValue (name, out currentPoolID))
			{
				GameObjectPool currentPool = gameObjectPools[currentPoolID];
				if (currentPool.createdObjects.Count - 1 < currentPool.maxAmount)
					currentPool.createdObjects.Add (CreateNewGameObject (currentPool.prefab));
				return GetGameObjectFromGameObjectPool (currentPool);
			}
			else
			{
				throw new InvalidOperationException (string.Format ("Pool object with name '{0}' does not exists.", name));
			}
		}

		private GameObject CreateNewGameObject (GameObject prefab)
		{
			GameObject newGameObject = Instantiate (prefab);
			newGameObject.transform.parent = poolParent.transform;
			return newGameObject;
		}

		private GameObject GetGameObjectFromGameObjectPool (GameObjectPool currentPool)
		{
			currentPool.currentIndex = (currentPool.currentIndex < currentPool.createdObjects.Count) ? currentPool.currentIndex + 1 : 0;
			GameObject poolObject = currentPool.GetGameObject (currentPool.currentIndex);
			poolObject.SetActive (false);
			poolObject.SetActive (true);
			return poolObject;
		}
	}
}