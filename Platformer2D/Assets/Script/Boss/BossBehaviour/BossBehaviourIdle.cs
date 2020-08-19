using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviourIdle : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss>().timeQuake = animator.GetComponent<Boss>().delayAttack;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<BossSign>().hitInfoY.collider != null)
        {
            if (animator.GetComponent<BossSign>().hitInfoY.collider.CompareTag("PlatformGround"))
            {
                float time = (animator.GetComponent<Boss>().timeQuake -= Time.deltaTime);
                if (time <= 0)
                {
                    animator.SetTrigger("animatorBossQuake");
                }
            }
        }

        if (!animator.GetComponent<Boss>().IsGround())
        {
            animator.SetBool("isAir", true);
        }

        if (animator.GetComponent<Boss>().IsGround())
        {
            animator.SetBool("isAir", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
