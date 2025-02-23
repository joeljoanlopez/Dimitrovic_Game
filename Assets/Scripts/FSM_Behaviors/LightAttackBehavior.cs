using System.Collections;
using UnityEngine;

namespace FSM_Behaviors
{
    public class LightAttackBehavior : StateMachineBehaviour
    {
        private AI_Data aiData;
        private bool attackStarted;
        private float currentTimer;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            aiData = animator.GetComponent<AI_Data>();
            attackStarted = false;
            currentTimer = aiData.lightAttackDelay;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!attackStarted && currentTimer <= 0)
            {
                aiData.lightAttackCollider.enabled = true;
                attackStarted = true;
                currentTimer = aiData.lightAttackTime;
            }
            if (attackStarted && currentTimer <= 0)
            {
                aiData.lightAttackCollider.enabled = false;
            }
            currentTimer -= Time.deltaTime;
        }
    }
}