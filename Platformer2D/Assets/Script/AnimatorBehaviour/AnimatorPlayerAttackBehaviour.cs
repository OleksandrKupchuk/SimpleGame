using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayerAttackBehaviour : StateMachineBehaviour
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Player>().PlayerAttack = true;
        animator.SetFloat("animatorPlayerWalk", 0);

        SoundManager.soundManagerInstance.PlaySound("Player_Attack");

        if (Player.PlayerInstance.PlayerOnGround)
        {
            Player.PlayerInstance.PlayerRigidbody.velocity = Vector2.zero;
        }

        //if (animator.CompareTag("Player"))
        //{
        //    if (Player.PlayerInstance.PlayerOnGround)
        //    {
        //        Player.PlayerInstance.PlayerRigidbody.velocity = Vector2.zero;
        //    }
        //}
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Player>().PlayerAttack = false;
        animator.ResetTrigger("animatorPlayerAttack");
        animator.GetComponent<Player>().PlayerSwordCollider.enabled = false;
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
