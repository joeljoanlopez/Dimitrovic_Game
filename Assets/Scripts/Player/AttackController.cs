using System;
using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
	public Collider2D attackCollider;
	public GameObject particlePrefab;
	private AttackHandler attackHandler;

	[Header("Light Attack")]
	public float lightAttackDelay = 0.1f;
	public float lightAttackTime = 0.2f;
	public float lightAttackDamage = 10f;
	
	[Header("Heavy Attack")]
	public float heavyAttackDelay = 0.3f;
	public float heavyAttackDamage = 20f;
	public float heavyAttackDistance = 10f;

	private void Start()
	{
		attackCollider.enabled = false;
		attackHandler = attackCollider.GetComponent<AttackHandler>();
	}

	private void OnLightAttack()
	{
		StartCoroutine(EnableAttackCollider(lightAttackDelay, lightAttackTime, lightAttackDamage));
	}
	
	private void OnHeavyAttack()
	{
		StartCoroutine(ThrowOrb(heavyAttackDelay, heavyAttackDamage));
	}

	private void Update()
	{
		print(transform.right);
	}

	private IEnumerator EnableAttackCollider(float attackDelay, float attackTime, float attackDamage)
	{
		attackHandler.SetDamage(attackDamage);
		yield return new WaitForSeconds(attackDelay);
		attackCollider.enabled = true;
		yield return new WaitForSeconds(attackTime);
		attackCollider.enabled = false;
	}
	
	private IEnumerator ThrowOrb(float attackDelay, float attackDamage)
	{
		yield return new WaitForSeconds(attackDelay);

		Vector2 startPoint = attackCollider.transform.position;
		Vector2 endPoint = (Vector2)startPoint + -(Vector2)transform.right * heavyAttackDistance;
		RaycastHit2D hit = Physics2D.Raycast(startPoint, -transform.right, heavyAttackDistance);


		if (hit.collider != null)
		{
			endPoint = hit.point;
			if (hit.collider.CompareTag("Enemy"))
				hit.collider.GetComponent<EnemyHealthController>().TakeDamage(attackDamage);
		}

		GameObject trailObject = Instantiate(particlePrefab, startPoint, Quaternion.identity);
		TrailMover trailMover = trailObject.GetComponent<TrailMover>();
		trailMover.Move(startPoint, endPoint);
	}
}