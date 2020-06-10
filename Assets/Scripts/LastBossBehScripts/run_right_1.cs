using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run_right_1 : StateMachineBehaviour
{
    Vector3 destination;
    public float speed = 2;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        kononoLos_controller controller = animator.GetComponent<kononoLos_controller>();
        destination = animator.transform.position + new Vector3(6, 0, 0);        
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, destination, speed * Time.deltaTime);
        if (animator.transform.position == destination)
        {
            animator.SetTrigger("idle1");
        }
    }

   

   
}
