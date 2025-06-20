using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform targetTransform; // Reference to the player transform
    public float angle;
    public float HorizontalOffset;
    public float VerticalOffset;
    public float lerFactor;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetTransform.position + new Vector3(HorizontalOffset * Mathf.Cos(angle), VerticalOffset, HorizontalOffset * Mathf.Sin(angle)), lerFactor);
    
        transform.LookAt(targetTransform); 
    }
}
