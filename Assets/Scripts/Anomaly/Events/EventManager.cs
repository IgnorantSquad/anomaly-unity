using System.Collections.Generic;

namespace Anomaly
{
    public class EventManager
    {
        private Actor targetActor = null;
        private List<IEventListener> listeners = new List<IEventListener>();

        public EventManager(Actor actor)
        {
            targetActor = actor;
        }

        public void Register(IEventListener listener)
        {
            listeners.Add(listener);
        }
        public void Unregister(IEventListener listener)
        {
            listeners.Remove(listener);
        }
        public void UnregisterAll()
        {
            listeners.Clear();
        }

        public void Send(Actor receiver)
        {
            receiver.EventManager.Receive(targetActor);
        }

        public void Receive(Actor sender)
        {
            foreach (var listener in listeners)
            {
                listener.Execute(sender);
            }
        }
    }
}