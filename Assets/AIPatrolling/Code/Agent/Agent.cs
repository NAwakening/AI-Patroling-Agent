using UnityEngine;

namespace N_Awakening.PatrolAgents
{
    #region Struct



    #endregion

    public class Agent : MonoBehaviour
    {
        #region References

        [SerializeField] protected FiniteStateMachine fsm;
        [SerializeField] protected Animator animator;

        #endregion

        #region Knobs

        [SerializeField] protected float movingSpeed;
        [SerializeField] protected float turningSpeed;

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



        #endregion

        #region GettersAndSetters

        public Animator GetAnimator
        {
            get { return animator; }
        }

        #endregion
    }
}