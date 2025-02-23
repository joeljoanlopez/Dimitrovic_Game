using System;
using UnityEngine;

namespace FSM_Behaviors
{
    public class AI_Data : MonoBehaviour
    {
        [Header ("Light attack")]
        public Collider2D lightAttackCollider;
        public float lightAttackDelay = 1f;
        public float lightAttackTime = 0.2f;
        public int lightAttackDamage = 10;

        private void Start()
        {
            lightAttackCollider.enabled = false;
        }
    }
}