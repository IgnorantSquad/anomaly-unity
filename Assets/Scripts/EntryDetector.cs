using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryDetector : Anomaly.CustomBehaviour
{
    private HashSet<Collider> entryList = new HashSet<Collider>();

    public UnityEngine.Events.UnityEvent<Collider> onTriggerEnter, onTriggerExit;
    public UnityEngine.Events.UnityEvent onEntryUpdated;

    public HashSet<Collider> EntryList => entryList;

    private void OnTriggerEnter(Collider other)
    {
        if (entryList.Contains(other)) return;

        entryList.Add(other);

        onTriggerEnter?.Invoke(other);
        onEntryUpdated?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!entryList.Contains(other)) return;

        entryList.Remove(other);

        onTriggerExit?.Invoke(other);
        onEntryUpdated?.Invoke();
    }
}
