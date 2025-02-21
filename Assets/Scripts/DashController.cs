using System;
using UnityEngine;

public class DashController : MonoBehaviour
{
	public float dashSpeed = 10f;
	public float dashDuration = 0.5f;
	public float dashCooldown = 1f;
	
	private float dashTime;
	private MovementController _movementController;
	private JumpController _jumpController;
	private Rigidbody2D _rigidBody;
	
	private void Start()
	{
		_movementController = GetComponent<MovementController>();
		_jumpController = GetComponent<JumpController>();
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		dashTime -= Time.deltaTime;
		
		if (dashTime <= 0) return;
		_movementController.enabled = true;
		_jumpController.enabled = true;
	}
	
	private void OnDash()
	{
		//Perform dash and disable movement and jump
		_movementController.enabled = false;
		_jumpController.enabled = false;
		dashTime = dashDuration;
		
		//Move in the current movement direction at dash speed for the duration of the dash
		_rigidBody.linearVelocity = new Vector2(_movementController.GetMovementDirection().x * dashSpeed, 0);
		dashTime -= Time.deltaTime;
	}
}