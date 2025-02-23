using UnityEngine;

namespace FSM_Behaviors
{
    public class WalkBehavior : StateMachineBehaviour
    {
        private AI_Data aiData;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            aiData = animator.GetComponent<AI_Data>();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            animator.ResetTrigger("Attack");
            animator.SetBool("isLight", false);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            
            if (Vector2.Distance(animator.transform.position, aiData.player.transform.position) < aiData.attackDistance)
            {
                int newState = Random.Range(1, 3);
                animator.SetBool("isLight", newState > 1);
                animator.SetTrigger("Attack");
                Debug.Log(animator.GetBool("isLight"));
                return;
            }
            
            if (aiData.player.transform.position.x < animator.transform.position.x)
                animator.transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                animator.transform.rotation = Quaternion.Euler(0, 180, 0);
            
            animator.transform.position = Vector2.MoveTowards(animator.transform.position,
                aiData.player.transform.position, aiData.speed * Time.deltaTime);
        }
    }
}