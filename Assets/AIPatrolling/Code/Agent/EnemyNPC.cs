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

        protected EnemyNPC_SO behaviour;

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



        #endregion

        #region GettersAndSetters

        public EnemyNPC_SO SetBehaviour
        {
            set { behaviour = value; }
        }

        #endregion
    }
}