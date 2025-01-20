using UnityEngine;

namespace N_Awakening.PatrolAgents
{
    #region Enum

    public enum States
    {
        IDLE,
        MOVING,
        TURNING
    }

    public enum StateMechanic
    {
        STOP,
        MOVE,
        TURN
    }

    #endregion

    public class FiniteStateMachine : MonoBehaviour
    {
        #region References

        [SerializeField] protected Rigidbody rb;
        [SerializeField] protected Agent agent;

        #endregion

        #region Public Methods

        public void EnteredState(States value)
        {
            Debug.Log("FSM - EnteredState(): Entered the finite state " + value);
        }

        public void StateMechanic(StateMechanic value)
        {
            agent.GetAnimator.SetBool(value.ToString(), true);
        }

        #endregion
    }
}

