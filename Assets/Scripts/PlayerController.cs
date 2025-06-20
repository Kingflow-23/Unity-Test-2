using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActions inputs;
    private Rigidbody rb;

    public float speed = 5f;
    public float accelerationFactor = 10f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckDistance = 0.2f;
    
    public enum PlayerState {GROUNDED, IN_AIR, DEAD}
    public PlayerState playerState;

    private Collider playerCollider;

    private void Awake()
    {
        inputs = new InputActions();
        rb = GetComponent<Rigidbody>();
        playerState = PlayerState.GROUNDED;
        playerCollider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        inputs.Movement.Enable();
        inputs.Movement.Jump.performed += Jump;
    }

    private void OnDisable()
    {
        inputs.Movement.Disable();
        inputs.Movement.Jump.performed -= Jump;
    }
 
    void Update()
    {
        switch(playerState) {
            case PlayerState.GROUNDED:
            case PlayerState.IN_AIR:
                Vector3 inputVector = inputs.Movement.Horizontal.ReadValue<Vector3>();
                Vector3 targetVelocity = inputVector * speed;  
                targetVelocity.y = rb.linearVelocity.y;

                rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, accelerationFactor * Time.deltaTime);

                CheckGrounded();
                break;

            case PlayerState.DEAD:
            // Handle death state
                break;
            
        }
    }

    private void CheckGrounded() {
        if (Physics.Raycast(transform.position, Vector3.down, playerCollider.bounds.extents.y + 0.1f)) {
            playerState = PlayerState.GROUNDED;
        }
        else
        {
            playerState = PlayerState.IN_AIR;
        }

    }

    private  void Jump(InputAction.CallbackContext context)
    {
        AudioManager.instance.PlaySFX("ButtonPress");
        {
            switch(playerState) {
                case PlayerState.GROUNDED:
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                    AudioManager.instance.PlaySFX("Jump");
                    break;
                case PlayerState.IN_AIR:
                    // Handle in-air jump logic if needed
                    break;
                case PlayerState.DEAD:
                    // Handle death state jump logic if needed
                    break;
            }
        }
    }

}
