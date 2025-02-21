using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
	public Collider2D attackCollider;
	private AttackHandler attackHandler;

	[Header("Light Attack")]
	public float lightAttackDelay = 0.1f;
	public float lightAttackTime = 0.2f;
	public float lightAttackDamage = 10f;
	
	[Header("Heavy Attack")]
	public float heavyAttackDelay = 0.3f;
	public float heavyAttackTime = 0.2f;
	public float heavyAttackDamage = 20f;

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
		StartCoroutine(EnableAttackCollider(heavyAttackDelay, heavyAttackTime, heavyAttackDamage));
	}

	private IEnumerator EnableAttackCollider(float attackDelay, float attackTime, float attackDamage)
	{
		attackHandler.SetDamage(attackDamage);
		yield return new WaitForSeconds(attackDelay);
		attackCollider.enabled = true;
		yield return new WaitForSeconds(attackTime);
		attackCollider.enabled = false;
	}
}