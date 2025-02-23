using UnityEngine;

namespace FSM_Behaviors
{
    public class IdleBehavior : StateMachineBehaviour
    {
        private AI_Data aiData;
        private float currentTime;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            aiData = animator.GetComponent<AI_Data>();
            currentTime = aiData.idleTime;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (currentTime <= 0)
            {
                int newState = Random.Range(1, 3);
                animator.SetTrigger("Normal");
            }
            
            currentTime -= Time.deltaTime;
        }
    }
}