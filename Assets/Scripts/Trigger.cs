using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{

    public UnityEvent triggerEvent = new UnityEvent();
    public UnityEvent untriggerEvent = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        triggerEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        untriggerEvent.Invoke();
    }
}
