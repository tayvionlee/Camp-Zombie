using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Events")]
public class GameEvents : ScriptableObject
{
    #region Event
    // store list of objects that listen for new events
    HashSet<EventListener> _listeners = new HashSet<EventListener>();

    public void Invoke()
    {
           foreach (var globalEventListerner in _listeners)
           globalEventListerner.RaiseEvent();
    }

    public void Register(EventListener gameEventListener) => _listeners.Add(gameEventListener);
    public void Deregister(EventListener gameEventListener) => _listeners.Remove(gameEventListener);
    #endregion
}

