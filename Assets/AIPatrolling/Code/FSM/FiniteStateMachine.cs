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

        #region RuntimeVariables

        protected States state;
        protected Vector3 moveDirection;
        protected float moveSpeed;
        protected float turnSpeed;
        protected float lerpCronometer;
        protected Vector3 initialValue;

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

        public void SetStatic()
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        public void SetForOnlyRotation()
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        public void SetForOnlyXMovement()
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
        }

        public void SetForMovement()
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
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
            lerpCronometer = 0f;
            initialValue = transform.position;
        }

        protected void ExecutingMovingState()
        {
            if (agent as PlayersAvatar)
            {
                rb.linearVelocity = moveDirection * moveSpeed;
                agent.GetModel.forward = Vector3.Slerp(agent.GetModel.forward, moveDirection.normalized, Time.fixedDeltaTime * turnSpeed);
            }
            else
            {
                //lerpCronometer += Time.fixedDeltaTime;
                //Debug.LogWarning("ExecutingMovingState() - " + lerpCronometer + " - " + turnSpeed);
                //Debug.LogWarning("Direction - " + moveDirection);
                //Debug.LogWarning("Lerp Percentage - " + lerpCronometer / moveSpeed);
                //transform.position = Vector3.Lerp(initialValue, moveDirection, lerpCronometer / moveSpeed);
                rb.linearVelocity = (moveDirection - transform.position).normalized * moveSpeed;
                transform.forward = Vector3.Slerp(transform.forward, (moveDirection - transform.position).normalized, Time.fixedDeltaTime * 2.5f);
                if (Vector3.Distance(transform.position, moveDirection) <= 0.1f)
                {
                    ((EnemyNPC)agent).GoToNextBehaviour();
                }
            }
        }

        protected void InitializeTurningState()
        {
            rb.linearVelocity = Vector3.zero;
            lerpCronometer = 0f;
            initialValue = transform.localRotation.eulerAngles;
        }

        protected void ExecutingTurningState()
        {
            lerpCronometer += Time.fixedDeltaTime;
            //Debug.LogWarning("ExecutingTurningState() - " + turningCronometer + " - " + turnSpeed);
            //Debug.LogWarning("Direction - " + moveDirection);
            //Debug.LogWarning("Lerp Percentage - " + turningCronometer / turnSpeed);
            if (turnSpeed > 0)
            {
                transform.localRotation = Quaternion.Euler(Vector3.Lerp(initialValue, moveDirection, lerpCronometer / turnSpeed));
            }
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

