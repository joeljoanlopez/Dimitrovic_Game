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

    [Header("Audio")]
    public AudioClip lightAttackSound;
    public AudioClip heavyAttackSound;
    private AudioSource attackAudioSource;

    private Animator animator;
    private int attackComboCount = 0; 
    private float lastAttackTime = 0f; 
    public float comboResetTime = 0.5f;

    private void Start()
	{
		attackCollider.enabled = false;
		attackHandler = attackCollider.GetComponent<AttackHandler>();
		attackAudioSource = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }

	private void OnLightAttack()
	{
        float timeSinceLastAttack = Time.time - lastAttackTime;

        if (timeSinceLastAttack > comboResetTime)
        {
            attackComboCount = 0; 
        }

        attackComboCount++; 

        if (attackComboCount == 1)
        {
            animator.SetTrigger("Meele1"); 
        }
        else if (attackComboCount == 2)
        {
            animator.SetTrigger("Meele2"); 
        }
        else
        {
            attackComboCount = 1;
            animator.SetTrigger("Meele1"); 
        }

        lastAttackTime = Time.time; 
        StartCoroutine(EnableAttackCollider(lightAttackDelay, lightAttackTime, lightAttackDamage));

        if (attackAudioSource != null && lightAttackSound != null)
            attackAudioSource.PlayOneShot(lightAttackSound);
    }
	
	private void OnHeavyAttack()
	{
        animator.SetTrigger("LongDistance");
        StartCoroutine(ThrowOrb(heavyAttackDelay, heavyAttackDamage));
		if (attackAudioSource && heavyAttackSound) attackAudioSource.PlayOneShot(heavyAttackSound);
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
		Vector2 endPoint = startPoint + (Vector2)transform.right * heavyAttackDistance;
		RaycastHit2D hit = Physics2D.Raycast(startPoint, transform.right, heavyAttackDistance);


		if (hit.collider != null && !hit.transform != transform)
		{
			endPoint = hit.point;
			print("Hit point: " + hit.point);
			if (hit.collider.CompareTag("Enemy"))
				hit.collider.GetComponent<EnemyHealthController>().TakeDamage(attackDamage);
		}

		GameObject trailObject = Instantiate(particlePrefab, startPoint, Quaternion.identity);
		TrailMover trailMover = trailObject.GetComponent<TrailMover>();
		trailMover.Move(startPoint, endPoint);
	}
}