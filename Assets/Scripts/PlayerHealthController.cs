using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerHealthController : MonoBehaviour, IRestartGameElement
    {
        public int maxHealth = 100;
        public bool isInvincible;
        private int currentHealth;

        private void Awake()
        {
            GameManager.m_instanceGameManager?.AddRestartGameElement(this);
        }
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
            GameManager.m_instanceGameManager.GameOver();
        }

        public void RestartGame()
        {
            currentHealth = maxHealth;
        }
    }
}