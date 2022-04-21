using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotSpeed;

    private Rigidbody rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * verticalInput;
        movement.Normalize();
        movement *= speed * Time.fixedDeltaTime;
        movement.y = rb.velocity.y;

        anim.SetFloat("Speed_f", verticalInput);
        rb.velocity = movement;

        transform.eulerAngles += Vector3.up * horizontalInput * rotSpeed * Time.fixedDeltaTime;
    }
}
