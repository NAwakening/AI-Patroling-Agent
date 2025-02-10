using System.Collections;
using UnityEngine;

namespace N_Awakening.PatrolAgents
{
    #region Struct



    #endregion

    public class EnemyNPC : Agent
    {
        #region References



        #endregion

        #region Knobs



        #endregion

        #region RunTumeVariables

        [SerializeField] protected EnemyNPC_SO behaviour;
        protected PatrolBehaviour currentBehaviour;
        protected int currentBehaviourIndex;

        #endregion

        #region UnityMethods

        void Start()
        {
            currentBehaviour = behaviour.behaviour[0];
            InitializeSubstate();
            InvokeStateMechanic();
            if (currentBehaviour.time >= 0)
            {
                StartCoroutine(TimerForEnemyBehaviour());
            }
        }

        void Update()
        {

        }

        #endregion

        #region LocalMethods

        protected void InvokeStateMechanic()
        {
            switch (currentBehaviour.stateMechanic)
            {
                case StateMechanic.STOP:
                    fsm.StateMechanic(StateMechanic.STOP);
                    break;
                case StateMechanic.MOVE:
                    fsm.StateMechanic(StateMechanic.MOVE);
                    break;
                case StateMechanic.TURN:
                    fsm.StateMechanic(StateMechanic.TURN);
                    break;
            }
        }

        protected void GoToNextBehaviour()
        {
            currentBehaviourIndex++;
            if (currentBehaviourIndex >= behaviour.behaviour.Length)
            {
                currentBehaviourIndex = 0;
            }
            currentBehaviour = behaviour.behaviour[currentBehaviourIndex];
            InitializeSubstate();
            InvokeStateMechanic();
            if (currentBehaviour.time >= 0)
            {
                StartCoroutine(TimerForEnemyBehaviour());
            }
        }

        protected void InitializeSubstate()
        {
            switch (currentBehaviour.stateMechanic)
            {
                case StateMechanic.STOP:
                    InitializeStopSubstateMechanic();
                    break;
                case StateMechanic.MOVE:
                    InitializeMoveSubstateMechanic();
                    break;
                case StateMechanic.TURN:
                    InitializeTurnSubstateMechanic();
                    break;
            }
        }

        protected void FinalizeSubstate()
        {
            switch (currentBehaviour.stateMechanic)
            {
                case StateMechanic.MOVE:
                    FinalizeMoveSubstateMechanic();
                    break;
                case StateMechanic.TURN:
                    FinalizeTurnSubstateMechanic();
                    break;
            }
        }

        #endregion

        #region PublicMethods

        public void SetStatic()
        {
            fsm.SetStatic();
        }

        public void SetForOnlyRotation()
        {
            fsm.SetForOnlyRotation();
        }

        public void SetForOnlyXMovement()
        {
            fsm.SetForOnlyXMovement();
        }

        public void SetForMovement()
        {
            fsm.SetForMovement();
        }

        #endregion

        #region SubStateMechanic

        protected void InitializeStopSubstateMechanic()
        {
            //fsm.SetMoveDirection = Vector3.zero;
            fsm.SetMoveSpeed = 0;
            fsm.SetTurnSpeed = 0;
        }

        protected void InitializeMoveSubstateMechanic()
        {
            fsm.SetMoveDirection = currentBehaviour.destinyDirection - transform.position;
            fsm.SetMoveSpeed = currentBehaviour.speed;
            fsm.SetTurnSpeed = 0;
        }

        protected void FinalizeMoveSubstateMechanic()
        {
            fsm.SetMoveDirection = Vector3.zero;
            fsm.SetMoveSpeed = 0;
            fsm.SetTurnSpeed = 0;
        }

        protected void InitializeTurnSubstateMechanic()
        {
            if (currentBehaviour.time == 0)
            {
                transform.localRotation = Quaternion.Euler(currentBehaviour.destinyDirection);
                fsm.SetTurnSpeed = currentBehaviour.time;
            }
            else
            {
                fsm.SetMoveDirection = currentBehaviour.destinyDirection;
                fsm.SetMoveSpeed = 0;
                fsm.SetTurnSpeed = currentBehaviour.time;
            }
        }

        protected void FinalizeTurnSubstateMechanic()
        {
            //fsm.SetMoveDirection = Vector3.zero;
            fsm.SetMoveSpeed = 0;
            fsm.SetTurnSpeed = 0;
        }

        #endregion

        #region Corrutines

        IEnumerator TimerForEnemyBehaviour()
        {
            yield return new WaitForSeconds(currentBehaviour.time);
            FinalizeSubstate();
            GoToNextBehaviour();
        }

        #endregion

        #region GettersAndSetters

        public EnemyNPC_SO SetBehaviour
        {
            set { behaviour = value; }
        }

        #endregion
    }
}