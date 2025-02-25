using System;
using UnityEngine;

namespace FSM_Behaviors
{
    public class AI_Data : MonoBehaviour
    {
        public GameObject player;

        [Header("General Data")]
        public float idleTime = 1f;
        public float speed = 2f;
        public float attackDistance = 1f;

        [Header ("Light attack")]
        public Collider2D lightAttackCollider;
        public float lightAttackDelay = 0.5f;
        public float lightAttackTime = 0.2f;
        public int lightAttackDamage = 10;

        [Header ("Heavy attack")]
        public Collider2D heavyAttackCollider;
        public float heavyAttackDelay = 1f;
        public float heavyAttackTime = 0.2f;
        public int heavyAttackDamage = 20;

        private void Start()
        {
            lightAttackCollider.enabled = false;
            heavyAttackCollider.enabled = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
        }
    }
}