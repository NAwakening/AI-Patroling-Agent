using System;
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
            Invoke("CleanFlags", 0.1f);
        }

        public void StateMechanic(StateMechanic value)
        {
            agent.GetAnimator.SetBool(value.ToString(), true);
        }

        #endregion

        #region LocalMethods

        protected void CleanFlags()
        {
            foreach (StateMechanic value in (StateMechanic[])Enum.GetValues(typeof(StateMechanic)))
            {
                agent.GetAnimator.SetBool(value.ToString(), false);
            }
        }

        #endregion
    }
}

