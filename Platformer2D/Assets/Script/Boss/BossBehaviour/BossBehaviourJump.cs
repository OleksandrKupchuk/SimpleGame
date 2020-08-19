using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviourJump : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss>().delayJump = 0.5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("target = " + animator.GetComponent<Boss>().Target);

        if (animator.GetComponent<Boss>().Target != null)
        {
            animator.SetTrigger("animatorBossAttack");
        }

        if (animator.GetComponent<Boss>().IsFalling)
        {
            //animator.SetBool("Jump", false);
            animator.SetBool("isFalling", true);
        }

        //Debug.Log("falling = " + animator.GetComponent<Boss>().IsFalling);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("animatorBossJumpAttack");
        animator.ResetTrigger("animatorBossJump");
    }

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
