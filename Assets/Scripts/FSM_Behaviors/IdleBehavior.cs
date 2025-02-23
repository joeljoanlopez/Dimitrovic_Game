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
                states newState = (states)Random.Range(0, System.Enum.GetValues(typeof(states)).Length);
                if (aiData.forceState)
                    newState = aiData.newForcedState;
                animator.SetTrigger(newState.ToString());
            }
            
            currentTime -= Time.deltaTime;
        }
    }
}