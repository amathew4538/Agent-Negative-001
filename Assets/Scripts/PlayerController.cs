using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Input Actions")]
    public InputAction MoveAction; // WASD
    public InputAction RollAction; // Shift

    [Header("Settings")]
    public float walkSpeed = 2.0f;
    public float rollSpeed = 5.0f;

    [Header("References")]
    public Animator animator;
    public PlayerHandController handController;
    public Vector2 rollDirection;
    public bool isRolling = false;


    public void OnEnable()
    {
        MoveAction.Enable();
        RollAction.Enable();
    }

    public void OnDisable()
    {
        MoveAction.Disable();
        RollAction.Disable();
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        handController ??= GetComponentInChildren<PlayerHandController>();
    }

    public void Update()
    {
       bool handIsRightOfPlayer = handController.transform.position.x > transform.position.x;

        float s = handIsRightOfPlayer ? 1f : -1f;
        transform.localScale = new Vector3(s, 1, 1);

        // Get Input
        Vector2 moveInput = MoveAction.ReadValue<Vector2>();

        // Check for Roll Input
        if (RollAction.WasPressedThisFrame() && !isRolling) // WaasPressedThisFrame means that the action doesnt repeat multiple times
        {
            StartRoll(moveInput);
        }

        // Movement Logic
        if (isRolling)
        {
            // roll movement
            transform.position += (Vector3)rollDirection * rollSpeed * Time.deltaTime;
        }
        else
        {
            // Normal walking movement
            bool isMoving = moveInput.magnitude > 0.1f;
            animator.SetBool("isWalking", isMoving);

            transform.position += (Vector3)moveInput * walkSpeed * Time.deltaTime;
        }
    }

    void StartRoll(Vector2 moveInput)
    {
        isRolling = true;
        
        // Fire Trigger in Animator
        animator.SetTrigger("RollTrigger");

        // Determine direction
        if (moveInput.magnitude > 0.1f)
        {
            rollDirection = moveInput.normalized;
        }
        else
        {
            // If standing still, roll right
            rollDirection = Vector2.right;
        }
    }

    // Call this via an Animation Event at end of roll clip
    public void EndRoll()
    {
        isRolling = false;
    }
}