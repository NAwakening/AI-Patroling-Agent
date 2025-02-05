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

        #region RuntimeMethods

        protected States state;
        protected Vector3 moveDirection;
        protected float moveSpeed;
        protected float turnSpeed;

        #endregion

        #region UnityMethods

        private void FixedUpdate()
        {
            switch (state)
            {
                case States.MOVING:
                    ExecutingMovingState();
                    break;      
                case States.TURNING:
                    ExecutingTurningState();
                    break;
            }
        }

        #endregion

        #region Public Methods

        public void EnteredState(States value)
        {
            state = value;
            switch (state)
            {
                case States.IDLE:
                    InitializeIdleState();
                    break;
                case States.MOVING:
                    InitializeMovingState();
                    break;
                case States.TURNING: 
                    InitializeTurningState();
                    break;
            }
            //Invoke("CleanFlags", 0.27f);
        }

        public void StateMechanic(StateMechanic value)
        {
            CleanFlags();
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

        #region FSMMethods

        protected void InitializeIdleState()
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        protected void InitializeMovingState()
        {
            rb.angularVelocity = Vector3.zero;
        }

        protected void ExecutingMovingState()
        {
            rb.linearVelocity = moveDirection * moveSpeed;
            if (agent as PlayersAvatar)
            {
                agent.GetModel.forward = Vector3.Slerp(agent.GetModel.forward, moveDirection.normalized, Time.fixedDeltaTime * turnSpeed);
            }
        }

        protected void InitializeTurningState()
        {
            rb.linearVelocity = Vector3.zero;
        }

        protected void ExecutingTurningState()
        {
            rb.angularVelocity = moveDirection * turnSpeed;
            //transform.forward = Vector3.Slerp(transform.forward, moveDirection.normalized, Time.fixedDeltaTime * turnSpeed);
        }

        #endregion

        #region GettersAndSetters

        public Vector3 SetMoveDirection
        {
            set { moveDirection = value; }
        }

        public float SetMoveSpeed
        {
            set { moveSpeed = value; }
        }

        public float SetTurnSpeed
        {
            set { turnSpeed = value; }
        }

        #endregion
    }
}

