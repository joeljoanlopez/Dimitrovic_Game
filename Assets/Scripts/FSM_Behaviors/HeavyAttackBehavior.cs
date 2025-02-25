using System.Collections;
using UnityEngine;

namespace FSM_Behaviors
{
    public class HeavyAttackBehavior : StateMachineBehaviour
    {
        private AI_Data aiData;
        private bool attackStarted;
        private float currentTimer;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            aiData = animator.GetComponent<AI_Data>();
            attackStarted = false;
            currentTimer = aiData.heavyAttackDelay;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!attackStarted && currentTimer <= 0)
            {
                aiData.heavyAttackCollider.enabled = true;
                attackStarted = true;
                currentTimer = aiData.heavyAttackTime;
            }
            if (attackStarted && currentTimer <= 0)
            {
                aiData.heavyAttackCollider.enabled = false;
            }
            currentTimer -= Time.deltaTime;
        }
    }
}