using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
        // listens for a game event
        [SerializeField] GameEvents _gameEvent;
        // acts on (performs unity event)
        [SerializeField] UnityEvent _unityEvent;

        // adds to the register once the program starts
        private void Awake() => _gameEvent.Register(gameEventListener: this);

        // removes it once event is done
        private void OnDestroy() => _gameEvent.Deregister(gameEventListener: this);

        // calls another invoke method for the unity event
        public void RaiseEvent() => _unityEvent.Invoke();
}

