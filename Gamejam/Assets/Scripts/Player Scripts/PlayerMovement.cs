using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Rigidbody rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    [SerializeField]
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        moveInput = new Vector3(_horizontal, 0, _vertical);
        moveVelocity = Vector3.ClampMagnitude(moveInput, 1.0f) * moveSpeed;

        HandleRotation();
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
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
