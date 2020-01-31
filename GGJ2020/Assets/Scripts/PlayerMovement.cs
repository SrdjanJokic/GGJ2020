using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private LayerMask groundMask = 0;
    [SerializeField] private float groundDistance = 0f;
    [SerializeField] private float playerSpeed = 12f;
    [SerializeField] private float jumpHeight = 10f;

    private CharacterController controller;
    private Vector3 jumpVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
        ApplyGravity();
    }

    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1.0f);

        Vector3 movement = moveDirection * playerSpeed * Time.deltaTime;

        controller.Move(movement);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // v = sqrt(height * -2 * gravity) => velocity needed to jump a certain height
            jumpVelocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);

            //AudioManager.instance.PlaySound((int)AudioManager.Sounds.Jump);
        }
    }

    private void ApplyGravity()
    {
        if(jumpVelocity.y > Physics.gravity.y)
        {
            jumpVelocity += Physics.gravity * Time.deltaTime;
        }

        controller.Move(jumpVelocity * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}