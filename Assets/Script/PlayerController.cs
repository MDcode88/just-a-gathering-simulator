using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;
        float rotationInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;

        // Muovi la sfera sull'asse Z
        Vector3 moveDirection = transform.TransformDirection(Vector3.forward) * moveInput;
        rb.MovePosition(rb.position + moveDirection);

        // Ruota la sfera attorno all'asse Y
        Quaternion rotationDelta = Quaternion.Euler(0, rotationInput, 0);
        rb.MoveRotation(rb.rotation * rotationDelta);
    }
}
