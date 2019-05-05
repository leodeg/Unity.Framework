using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Events
{
    [CreateAssetMenu(menuName = "LeoDeg/Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        List<GameEventListener> listeners = new List<GameEventListener>();

        public void Register(GameEventListener l)
        {
            listeners.Add(l);
        }

        public void UnRegister(GameEventListener l)
        {
            listeners.Remove(l);
        }

        public void Raise()
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].Response();
            }
        }
    }
}
