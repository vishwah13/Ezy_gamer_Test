using System.Collections.Generic;
using UnityEngine;

namespace Vishwah.ScriptableEvents
{
   [CreateAssetMenu(fileName = "New game Event",menuName = "game event",order = 52)]
   public class GameEvent : ScriptableObject
   {
      private List<GameEventListener> _listeners = new List<GameEventListener>();

      public void Raise()
      {
         for (int i = _listeners.Count - 1; i >= 0; i--)
         {
            _listeners[i].OnEventRaised();
         }
      }

      public void RegisterListener(GameEventListener listener)
      {
         _listeners.Add(listener);
      }

      public void UnRegisterListener(GameEventListener listener)
      {
         _listeners.Remove(listener);
      }

   }
}
