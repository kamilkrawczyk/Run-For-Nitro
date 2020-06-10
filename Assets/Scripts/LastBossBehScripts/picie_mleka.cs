using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picie_mleka : StateMachineBehaviour
{
    kononoLos_controller controller;
    float healthBeforeHeal;
    float healthAfterHeal;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<kononoLos_controller>();
        healthBeforeHeal = controller.healthBar.fillAmount;
        healthAfterHeal = healthBeforeHeal + 0.25f;                                   
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.healthBar.fillAmount += 0.001f;       
        if(controller.healthBar.fillAmount >= healthAfterHeal)
        {
            animator.SetTrigger("idle1");
        }

    }
  

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

  
}
