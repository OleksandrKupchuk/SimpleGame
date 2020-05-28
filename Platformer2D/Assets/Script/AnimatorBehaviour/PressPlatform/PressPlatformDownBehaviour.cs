using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPlatformDownBehaviour : StateMachineBehaviour
{
    Vector2 defaultPlatformCollider2DSize = new Vector2(0.16f, 0.1631193f);
    Vector2 defaultPlatformCollider2DOffset = new Vector2(0f, -0.00177088f);
    Vector2 preesPlatformCollider2DSize = new Vector2(0.16f, 0.1482385f);
    Vector2 preesPlatformCollider2DOffset = new Vector2(0f, -0.009211291f);
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<BoxCollider2D>().size = preesPlatformCollider2DSize;
        //animator.GetComponent<BoxCollider2D>().offset = preesPlatformCollider2DOffset;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<BoxCollider2D>().size = defaultPlatformCollider2DSize;
        //animator.GetComponent<BoxCollider2D>().offset = defaultPlatformCollider2DOffset;
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
