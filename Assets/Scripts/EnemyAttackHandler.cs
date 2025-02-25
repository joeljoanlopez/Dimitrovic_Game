using System;
using FSM_Behaviors;
using UnityEngine;

namespace DefaultNamespace
{
    public enum AttackType
    {
        Light,
        Heavy,
        Area,
        Jump,
    }
    
    public class EnemyAttackHandler : MonoBehaviour
    {
        public AttackType attackType;
        public AI_Data aiData;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            PlayerHealthController playerHealth = other.GetComponent<PlayerHealthController>();
            playerHealth.TakeDamage(DecideDamage());
        }
        
        private int DecideDamage()
        {
            switch (attackType)
            {
                case AttackType.Light:
                    return aiData.lightAttackDamage;
                case AttackType.Heavy:
                    return aiData.heavyAttackDamage;
                case AttackType.Area:
                    return aiData.areaAttackDamage;
                case AttackType.Jump:
                    return aiData.jumpAttackDamage;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}