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
            
            if (aiData.player.transform.position.x < animator.transform.position.x)
                animator.transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                animator.transform.rotation = Quaternion.Euler(0, 180, 0);
            
            if (animator.GetBool("Escape") ^ isPlayerNear(animator)) // ^ means different
            {
                int newState = Random.Range(1, 3);
                animator.SetBool("isLight", newState > 1);
                animator.SetTrigger("Attack");
                Debug.Log(animator.GetBool("isLight"));
                return;
            }
            
            Vector3 targetPosition = new Vector3(aiData.player.transform.position.x, animator.transform.position.y, 0);
            
            if (animator.GetBool("Escape"))
            {
                animator.transform.position = Vector2.MoveTowards(animator.transform.position,
                    targetPosition, -aiData.speed * Time.deltaTime);
            }
            else
            {
                animator.transform.position = Vector2.MoveTowards(animator.transform.position,
                    targetPosition, aiData.speed * Time.deltaTime);
            }
        }
        
        private bool isPlayerNear(Animator animator)
        {
            return Vector2.Distance(aiData.player.transform.position, animator.transform.position) < aiData.attackDistance;
        }
    }
}