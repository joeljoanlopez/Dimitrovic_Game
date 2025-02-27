using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerHealthController : MonoBehaviour
    {
        public int maxHealth = 100;
        public bool isInvincible;
        private int currentHealth;
        
        private void Start()
        {
            currentHealth = maxHealth;
        }
        
        public void TakeDamage(int damage)
        {
            if (isInvincible) return;
            
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}