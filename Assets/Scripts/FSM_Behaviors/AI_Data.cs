using System;
using UnityEngine;

namespace FSM_Behaviors
{
    public class AI_Data : MonoBehaviour
    {
        public GameObject player;
        public float idleTime = 1f;
        public float speed = 2f;
        public float attackDistance = 1f;
        
        [Header ("Light attack")]
        public Collider2D lightAttackCollider;
        public float lightAttackDelay = 1f;
        public float lightAttackTime = 0.2f;
        public int lightAttackDamage = 10;
        
        private void Start()
        {
            lightAttackCollider.enabled = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
        }
    }
}