using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rigidBody;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rigidBody.linearVelocity = new Vector2(horizontalInput * speed, rigidBody.linearVelocityY);
    }
}
