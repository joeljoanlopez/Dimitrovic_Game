using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour, IRestartGameElement
{
    public float speed = 10f;
    public Vector3 playerInitialPosition;
    private Rigidbody2D rigidBody;
    private Vector2 moveInput;
    [Header("Audio")]
    public AudioClip moveSound;
    private AudioSource moveAudioSource;
    private Animator animator;

    void Start()
    {
        GameManager.m_instanceGameManager?.AddRestartGameElement(this);

        rigidBody = GetComponent<Rigidbody2D>();
        moveAudioSource = GetComponent<AudioSource>();
        animator = GetComponentInChildren <Animator>();
        playerInitialPosition = transform.position;
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
        if (moveInput.x < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (moveInput.x > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = new Vector2(moveInput.x * speed, rigidBody.linearVelocityY);
        animator.SetFloat("Horizontal", Mathf.Abs(moveInput.x));
    }

    public Vector2 GetMovementDirection()
    {
        return moveInput;
    }

    public void RestartGame()
    {
        transform.position = playerInitialPosition;
    }
}
