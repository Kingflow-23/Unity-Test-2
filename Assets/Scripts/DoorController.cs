using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    
    public float speed;
    private float closedY;
    public float openY;

    private Coroutine activeCoroutine;

    void Start()
    {
        closedY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        if (activeCoroutine != null) 
        {
            StopCoroutine(activeCoroutine);
        }
        AudioManager.instance.PlaySFX("DoorMove");
        activeCoroutine = StartCoroutine(OpenDoor());
    }

    private IEnumerator OpenDoor()
    {
        while(transform.position.y < closedY + openY) 
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, closedY + openY, transform.position.z);
        activeCoroutine = null;
    }

    public void Close()
    {
        if (activeCoroutine != null) 
        {
            StopCoroutine(activeCoroutine);
        }
        activeCoroutine = StartCoroutine(CloseDoor());
    }

    private IEnumerator CloseDoor()
    {
        while(transform.position.y > closedY) 
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, closedY, transform.position.z);
        activeCoroutine = null;
    }
}
