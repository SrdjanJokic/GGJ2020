using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private bool isBlue;
    public bool isControlled { get; set; }
    private Rigidbody body;
    public float speed;
    public float rotationSpeed;
    private float vertical;
    private float horizontal;

    void Start()
    {
        body = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        if(isControlled)
        {
            if(isBlue)
            {
                vertical = Input.GetAxis("Vertical");
                horizontal = Input.GetAxis("Horizontal");
            }
            else
            {
                vertical = Input.GetAxis("VerticalArrows");
                horizontal = Input.GetAxis("HorizontalArrows");
            }

            Vector3 velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
            velocity.y = body.velocity.y;
            body.velocity = velocity;
            transform.Rotate((transform.up * horizontal) * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
