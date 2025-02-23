using System;
using UnityEngine;

namespace FSM_Behaviors
{
    public enum states
    {
        Normal,
        Jump,
        Area
    }
    
    public class AI_Data : MonoBehaviour
    {
        [Header("Debug")]
        public bool forceState;
        public states newForcedState;
        
        [Header("General Data")]
        public GameObject player;
        public float idleTime = 1f;
        public float speed = 2f;
        public float attackDistance = 1f;

        [Header("Ground Check")]
        public Transform groundCheck;
        public float groundCheckRadius = 0.2f;
        public LayerMask groundLayer;
        
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
        
        [Header ("Jump attack")]
        public Collider2D jumpAttackCollider;
        public Vector2 jumpForce = Vector2.one;
        public float jumpAttackDelay = 1f;
        public float jumpAttackTime = 0.2f;
        public int jumpAttackDamage = 15;
        
        private void Start()
        {
            lightAttackCollider.enabled = false;
            heavyAttackCollider.enabled = false;
            jumpAttackCollider.enabled = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}