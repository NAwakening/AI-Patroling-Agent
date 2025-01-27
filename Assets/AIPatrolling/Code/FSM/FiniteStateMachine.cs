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
                    rb.linearVelocity = moveDirection * moveSpeed;
                    Debug.Log(moveDirection);
                    if (agent as PlayersAvatar)
                    {
                        agent.GetModel.forward = Vector3.Slerp(agent.GetModel.forward, moveDirection.normalized, Time.fixedDeltaTime * turnSpeed);
                    }
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
                case States.TURNING: 
                    InitializeTurningState();
                    break;
            }
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

        #region FSMMethods

        protected void InitializeIdleState()
        {
            rb.linearVelocity = Vector3.zero;
        }

        protected void InitializeTurningState()
        {
            rb.linearVelocity = Vector3.zero;
        }

        #endregion

        #region GettersAndSetters

        public Vector3 SetMoveDirection
        {
            set { moveDirection = value; Debug.Log("Move Direction: " + moveDirection.ToString()); }
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

