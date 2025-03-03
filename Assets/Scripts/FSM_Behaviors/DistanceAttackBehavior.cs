using DefaultNamespace;
using UnityEngine;

namespace FSM_Behaviors
{
    public class DistanceAttackBehavior : StateMachineBehaviour
    {
        private AI_Data aiData;
        private bool canAttack = true;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            aiData = animator.GetComponent<AI_Data>();
            canAttack = true;
        }
        
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (Vector2.Distance(animator.transform.position, aiData.player.transform.position) >
                aiData.distanceAttackRange)
            {
                animator.transform.position = Vector2.MoveTowards(animator.transform.position,
                    aiData.player.transform.position, aiData.speed * Time.deltaTime);
            }
            else
            {
                if (!canAttack) return;
                
                Vector3 startPoint = aiData.distanceAttackOrigin.position;
                Vector2 direction = (aiData.player.transform.position - startPoint).normalized;
                RaycastHit2D hit =
                    Physics2D.Raycast(startPoint, direction, aiData.distanceAttackRange);
                
                if (hit.collider != null && hit.collider.gameObject == aiData.player)
                {
                    aiData.player.GetComponent<PlayerHealthController>().TakeDamage(aiData.distanceAttackDamage);
                }
                
                GameObject trailObject = Instantiate(aiData.projectilePrefab, startPoint, Quaternion.identity);
                TrailMover trailMover = trailObject.GetComponent<TrailMover>();
                trailMover.Move(startPoint, hit.point);
                animator.SetTrigger("Idle");
                canAttack = false;
            }
        }
    }
}