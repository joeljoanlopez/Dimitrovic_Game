using System;
using UnityEngine;

public class JumpController : MonoBehaviour
{
	public float jumpForce = 10f;
	private Rigidbody2D rigidBody;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	private void OnJump()
	{
		// Jump only if the player is on the ground
		if (IsGrounded())
		{
			rigidBody.linearVelocity = Vector2.up * jumpForce * Time.deltaTime;
		}
	}

	private bool IsGrounded()
	{
		return true;
	}
}