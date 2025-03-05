using System;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 15f; // Fuerza del salto ajustada
    public float fallMultiplier = 2.5f;  // Multiplicador de gravedad al caer (aumenta la caída)
    public float lowJumpMultiplier = 2f; // Multiplicador de gravedad si el salto es corto (cuando el jugador mantiene el botón de salto)

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rigidBody;

    [Header("Audio")]
    public AudioClip jumpSound;
    private AudioSource jumpAudioSource;

    private Animator animator;

    private bool isGrounded;
    private bool isJumping;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        jumpAudioSource = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Comprobar si el jugador está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("OnFloor", isGrounded); // Activar la animación de estar en el suelo

        // Si está tocando el suelo y el jugador presiona el botón de salto, hacer el salto
        if (isGrounded && Input.GetButtonDown("Jump") && !isJumping)
        {
            OnJump();
        }

        // Si el jugador ya está en el aire y mantiene presionado el botón de salto, ajustar la gravedad para saltos más cortos
        if (rigidBody.linearVelocity.y < 0)
        {
            rigidBody.gravityScale = fallMultiplier; // Si está cayendo, aumenta la gravedad
        }
        else if (rigidBody.linearVelocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidBody.gravityScale = lowJumpMultiplier; // Si el jugador no mantiene el salto, disminuye la gravedad
        }
        else
        {
            rigidBody.gravityScale = 1f; // Gravedad normal cuando no está cayendo ni saltando
        }
    }

    private void OnJump()
    {
        animator.SetTrigger("Jump"); // Activar la animación de salto

        if (isGrounded)
        {
            // Aplicar la fuerza de salto
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpForce);
            if (jumpAudioSource != null && jumpSound != null)
            {
                jumpAudioSource.PlayOneShot(jumpSound); // Reproducir sonido del salto
            }
            isJumping = true; // Indicar que está saltando
        }
    }

    // Esto es útil para cuando se dibujan Gizmos en la vista de escena
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius); // Ver el área de detección del suelo
    }

    // Si el jugador toca el suelo, restablecer el estado de salto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGrounded)
        {
            isJumping = false; // Permitir que el jugador salte nuevamente
        }
    }
}
