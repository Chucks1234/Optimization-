using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;
    private int floorMask;
    private float camRayLength = 100f;

    int id_walking = Animator.StringToHash("IsWalking");

    IA_ playerActions;
    private Vector2 moveInput;
    private Vector2 lookInput;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        // Input Actions
        playerActions = new IA_();
        playerActions.Player.Enable();

        playerActions.Player.Move.performed += OnMove;
        playerActions.Player.Move.canceled += OnMove;
        playerActions.Player.Look.performed += OnLook;
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        Move();
        Turning();
        Animating();

    }

    void Move()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        movement = direction * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating()
    {
        //bool walking = h != 0f || v != 0f;
        bool walking = moveInput.x != 0f || moveInput.y != 0f;

        anim.SetBool(id_walking, walking);
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
    void OnLook(InputAction.CallbackContext ctx)
    {

        lookInput = ctx.ReadValue<Vector2>();

    }
}
