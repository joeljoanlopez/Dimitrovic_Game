using Unity.VisualScripting;
using UnityEngine;

namespace FSM_Behaviors
{
    public class JumpAttackBehavior : StateMachineBehaviour
    {
        private AI_Data aiData;
        private bool hasJumped;
        private bool attackStarted;
        private float currentTimer;
        private Rigidbody2D rb;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            aiData = animator.GetComponent<AI_Data>();
            rb = animator.GetComponent<Rigidbody2D>();
            hasJumped = false;
            attackStarted = false;
            currentTimer = aiData.jumpAttackDelay;
            
            Vector2 direction = (aiData.player.transform.position - animator.transform.position).normalized;
            
            rb.AddForce(new Vector2(direction.x * aiData.jumpForce.x, aiData.jumpForce.y), ForceMode2D.Impulse);
            hasJumped = true;
            
            if (aiData.player.transform.position.x < animator.transform.position.x)
                animator.transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                animator.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            bool isGrounded = Physics2D.Raycast(aiData.groundCheck.position, Vector2.down, aiData.groundCheckRadius, aiData.groundLayer);
            
            if (hasJumped && isGrounded && rb.linearVelocity.y <= 0)
            {
                if (currentTimer <= 0)
                {
                    if (!attackStarted)
                    {
                        aiData.jumpAttackCollider.enabled = true;
                        attackStarted = true;
                        currentTimer = aiData.jumpAttackTime;
                    }
                    else
                    {
                        aiData.jumpAttackCollider.enabled = false;
                    }
                }
                
                currentTimer -= Time.deltaTime;
            }
        }
    }
}