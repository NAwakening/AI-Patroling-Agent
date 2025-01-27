using System;
using UnityEngine;

namespace N_Awakening.PatrolAgents
{
    public class FSM_StateMachineBehaviour : StateMachineBehaviour
    {
        public States state;


        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.gameObject.transform.parent.GetComponent<FiniteStateMachine>().EnteredState(state);
        }
    }
}