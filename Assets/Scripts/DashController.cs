using System;
using System.Collections;
using UnityEngine;

public class DashController : MonoBehaviour
{
	public bool dashing = false;
	public float dashSpeed = 10f;
	public float dashDuration = 0.5f;
	public float dashCooldown = 1f;
	public LayerMask iFrameLayer;
	
	private bool canDash;
	private MovementController _movementController;
	private JumpController _jumpController;
	private Rigidbody2D _rigidBody;
	
	private void Start()
	{
		_movementController = GetComponent<MovementController>();
		_jumpController = GetComponent<JumpController>();
		_rigidBody = GetComponent<Rigidbody2D>();
		canDash = true;
	}
	
	private void OnDash()
	{
		if (canDash) 
			StartCoroutine(Dash());
	}
	
	private IEnumerator Dash()
	{
		canDash = false;
		dashing = true;
		_movementController.enabled = false;
		_jumpController.enabled = false;
		int originalLayer = gameObject.layer;
		gameObject.layer = Mathf.RoundToInt(Mathf.Log(iFrameLayer.value, 2));

		_rigidBody.linearVelocity = new Vector2(_movementController.GetMovementDirection().x * dashSpeed, 0);

		yield return new WaitForSeconds(dashDuration);

		gameObject.layer = originalLayer;
		_rigidBody.linearVelocity = Vector2.zero;
		_movementController.enabled = true;
		_jumpController.enabled = true;
		dashing = false;

		yield return new WaitForSeconds(dashCooldown);
		canDash = true;
	}
}