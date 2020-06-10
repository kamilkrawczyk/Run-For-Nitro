using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placz : StateMachineBehaviour
{
    public float time = 0;
    public float maxTime = 5;
    private Player playerScript;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();  
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        if(time > maxTime)
        {
            animator.SetTrigger("idle1");
        }

        if(animator.GetComponent<kononoLos_controller>().isPlayerOnTheLeft) //player on the left
        {
            playerScript.velocity.x += 0.5f;
        }
        else if(!animator.GetComponent<kononoLos_controller>().isPlayerOnTheLeft)//right
        {
            playerScript.velocity.x -= 0.5f;
        }
    }

   
    

  
}
