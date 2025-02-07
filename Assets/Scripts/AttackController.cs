using System;
using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
	public Collider2D attackCollider;
	public float attackTime = 0.5f;

	private void Start()
	{
		attackCollider.enabled = false;
	}

	private void OnAttack()
	{
		StartCoroutine(EnableAttackCollider());
	}

	private IEnumerator EnableAttackCollider()
	{
		attackCollider.enabled = true;
		yield return new WaitForSeconds(attackTime);
		attackCollider.enabled = false;
	}
}