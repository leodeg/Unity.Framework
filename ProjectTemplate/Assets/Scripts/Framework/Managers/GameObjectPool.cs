using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Framework
{
    /// <summary>
    /// Handler of a game objects
    /// </summary>
    [System.Serializable]
    public class GameObjectPool
    {
        public GameObject prefab;
		public string prefabName;
        public int maxAmount = 10;

        [HideInInspector]
        public int currentIndex = 0;

        [HideInInspector]
        public List<GameObject> createdObjects = new List<GameObject> ();

        public GameObject GetGameObject (int index)
        {
            return createdObjects[index];
        }
    }
}