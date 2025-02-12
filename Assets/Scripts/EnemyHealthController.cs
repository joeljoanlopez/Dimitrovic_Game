using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
	[Header("Health")]
	public float health = 100f;

	public void TakeDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
			Die();
	}

	public void Die()
	{
		//The enemy will die, the enemy will be destroyed
		GameObject.Destroy(this.gameObject);
	}
}