using System;
using UnityEngine;

public class JumpController : MonoBehaviour
{
	[Header("Jump Settings")]
	public float jumpForce = 750f;
	
	[Header("Ground Check")]
	public Transform groundCheck;
	public float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	
	private Rigidbody2D rigidBody;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	private void OnJump()
	{
		bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		if (isGrounded)
			rigidBody.linearVelocity = Vector2.up * jumpForce * Time.deltaTime;
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
	}
}