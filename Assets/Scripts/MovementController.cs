using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rigidBody;
    private Vector2 moveInput;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        if (moveInput.x < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (moveInput.x > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void FixedUpdate()
    {
        rigidBody.linearVelocity = new Vector2(moveInput.x * speed, rigidBody.linearVelocityY);
    }
}
