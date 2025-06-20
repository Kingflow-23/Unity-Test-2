using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour
{
    
    private float closedHeight;
    private Coroutine activeCoroutine;

    public float openOffset;
    public float speed;

    void Start()
    {
        closedHeight = transform.position.y;
    }

    void Update()
    {
        
    }

    public void OpenDoor()
    {
        if (activeCoroutine != null)
        {
            StopCoroutine(activeCoroutine);
        }
        activeCoroutine = StartCoroutine(OpenDoorRoutine());
    }

    public void CloseDoor()
    {
        if (activeCoroutine != null)
        {
            StopCoroutine(activeCoroutine);
        }
        activeCoroutine = StartCoroutine(CloseDoorRoutine());
    }
    private IEnumerator OpenDoorRoutine()
    {
        while (transform.position.y < closedHeight + openOffset)
        {
            yield return null;
            transform.position += speed * Time.deltaTime * Vector3.up; 
        }
        transform.position = new Vector3(transform.position.x, closedHeight + openOffset, transform.position.z);
        activeCoroutine = null; // Reset the coroutine reference after opening
    }   

    private IEnumerator CloseDoorRoutine()
    {
        while (transform.position.y > closedHeight)
        {
            yield return null;
            transform.position -= speed * Time.deltaTime * Vector3.up; 
        }
        transform.position = new Vector3(transform.position.x, closedHeight, transform.position.z);
        activeCoroutine = null; // Reset the coroutine reference after closing
    }
}
