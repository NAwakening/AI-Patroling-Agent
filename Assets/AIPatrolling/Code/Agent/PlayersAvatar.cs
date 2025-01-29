using UnityEngine;
using UnityEngine.InputSystem;

namespace N_Awakening.PatrolAgents
{
    #region Struct



    #endregion

    public class PlayersAvatar : Agent
    {
        #region References

        

        #endregion

        #region Knobs



        #endregion

        #region RunTumeVariables



        #endregion

        #region UnityMethods

        void Start()
        {

        }

        void Update()
        {

        }

        #endregion

        #region LocalMethods

        

        #endregion

        #region PublicMethods

        public void OnMove(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                fsm.SetMoveDirection = new Vector3(value.ReadValue<Vector2>().x, 0f, value.ReadValue<Vector2>().y);
                fsm.SetMoveSpeed = movingSpeed;
                fsm.SetTurnSpeed = turningSpeed;
                fsm.StateMechanic(StateMechanic.MOVE);
            }
            else if (value.canceled)
            {
                fsm.SetMoveDirection = Vector3.zero;
                fsm.SetMoveSpeed = 0;
                fsm.SetTurnSpeed = 0;
                fsm.StateMechanic(StateMechanic.STOP);
            }
        }

        #endregion

        #region GettersAndSetters

        

        #endregion
    }
}

