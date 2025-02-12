using UnityEngine;

	public class AttackHandler : MonoBehaviour
	{
		private float damage = 10f;
		
		public void SetDamage(float damage)
		{
			this.damage = damage;
		}
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!other.CompareTag("Enemy"))
				return;

			EnemyHealthController enemyHealth = other.GetComponent<EnemyHealthController>();
			enemyHealth.TakeDamage(damage);
		}
	}