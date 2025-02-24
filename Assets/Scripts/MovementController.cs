using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rigidBody;
    private Vector2 moveInput;
    [Header("Audio")]
    public AudioSource moveAudioSource;
    public AudioClip moveSound;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (moveInput.sqrMagnitude > 0.1f && moveAudioSource != null && moveSound != null)
        {
            moveAudioSource.PlayOneShot(moveSound);
        }
    }

    private void Update()
    {
        if (moveInput.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (moveInput.x < 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    void FixedUpdate()
    {
        rigidBody.linearVelocity = new Vector2(moveInput.x * speed, rigidBody.linearVelocityY);
    }
}
