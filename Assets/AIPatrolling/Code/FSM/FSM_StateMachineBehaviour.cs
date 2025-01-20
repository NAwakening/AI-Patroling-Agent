using UnityEngine;

namespace N_Awakening.PatrolAgents
{
    public class FSM_StateMachineBehaviour : StateMachineBehaviour
    {
        public States state;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("I entered this State " + state.ToString());
            animator.gameObject.GetComponent<FiniteStateMachine>().EnteredState(state);
        }
    }

}