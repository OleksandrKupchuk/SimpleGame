using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviourAttack : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss>().BossAttack = true;
        //animator.GetComponent<Boss>().BossRigidbody.velocity = Vector2.zero;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss>().timeFatique -= Time.deltaTime;

        if(animator.GetComponent<Boss>().timeFatique <= 0 && animator.GetComponent<Boss>().IsGround())
        {
            //Debug.Log("ya tyt");
            //Debug.Log("ground = " + animator.GetComponent<Boss>().IsGround());
            animator.GetComponent<Boss>().timeAttack = animator.GetComponent<Boss>().delayAttack;
            animator.GetComponent<Boss>().BossAttack = false;
            animator.SetBool("animatorBossFatigue", true);
        }

        else if(animator.GetComponent<Boss>().timeFatique <= 0 && !animator.GetComponent<Boss>().IsGround())
        {
            animator.SetBool("animatorBossFatigue", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss>().BossAttack = false;
        animator.ResetTrigger("animatorBossAttack");
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
