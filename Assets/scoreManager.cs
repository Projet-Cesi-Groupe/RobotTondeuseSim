using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
[SerializeField] public List<TriggerWithCustomEventBehavior> triggerWithCustomEventBehaviors;
[SerializeField] private int score = 0;

private void OnEnable()
{
    foreach (var triggerWithCustomEventBehavior in triggerWithCustomEventBehaviors)
    {
        triggerWithCustomEventBehavior.onTriggerEnterEvent.AddListener(OnTriggerEnterEventByScript);
    }
    
}

private void OnDisable()
{
    foreach (var triggerWithCustomEventBehavior in triggerWithCustomEventBehaviors)
    {
        triggerWithCustomEventBehavior.onTriggerEnterEvent.RemoveListener(OnTriggerEnterEventByScript);
    }
}

private void OnTriggerEnterEventByScript()
{
    score++;
    Debug.Log("[scoreManager] Score: " + score);
}


}
