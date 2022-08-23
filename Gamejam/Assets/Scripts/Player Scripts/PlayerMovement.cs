using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PlayerMovement : MonoBehaviour
{
    [Header("Key Binds")]
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    public bool isGrounded;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float sprintSpeed;
    [SerializeField]
    private float groundDrag;

    private Rigidbody rb;

    public bool isMoving;

    [Header("Post Processing")]
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private Light light;
    private PostProcessVolume v;
    private Vignette vignette;

    public static float lightLife;
    public static float vignetteLife;

    public static MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        idle
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        v = mainCamera.GetComponent<PostProcessVolume>();
        v.profile.TryGetSettings(out vignette);

        isMoving = false;

        lightLife = 2.75f;
        vignetteLife = 0.35f;
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

        if(Input.GetKey(KeyCode.W))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        StateHandler();

        HandleRotation();
    }

    private void StateHandler()
    {
        if (isGrounded && isMoving && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, .05f);

            light.range = lightLife + 2.25f;
            vignette.smoothness.value = 0.6f;

            anim.SetInteger("Run", 1);
            anim.SetInteger("Walk", 0);
        }
        else if (isGrounded && isMoving)
        {
            state = MovementState.walking;
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, .1f);
            vignette.intensity.value = SoulsBar.vignette.intensity.value;
            vignette.smoothness.value = 1f;

            light.range = lightLife;

            anim.SetInteger("Walk", 1);
            anim.SetInteger("Run", 0);
        }
        else
        {
            light.range = lightLife;
            vignette.intensity.value = SoulsBar.vignette.intensity.value;

            anim.SetInteger("Walk", 0);
            anim.SetInteger("Run", 0);
            state = MovementState.idle;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            HandleMovement();
        }
    }

    void HandleMovement()
    {
        rb.velocity = transform.forward * moveSpeed;
    }

    void HandleRotation()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }
}
