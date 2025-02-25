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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
        }
    }
}