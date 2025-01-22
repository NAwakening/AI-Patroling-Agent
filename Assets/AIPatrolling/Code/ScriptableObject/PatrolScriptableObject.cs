using UnityEngine;

namespace N_Awakening.PatrolAgents
{
    #region Enum

    public enum BehaviourType
    {
        STOP,
        MOVE_TO_WAYPOINT,
        ROTATE_TO_DIRECTION
    }

    #endregion

    #region Struct

    [System.Serializable]
    public struct PatrolBehaviour
    {
        public BehaviourType type; 
        public Vector3 direction;
        public float time;
        public float speed;
    }

    #endregion

    [CreateAssetMenu(menuName = "AIPatroling/NewPatrolBehaviour")]
    public class PatrolScriptableObject : ScriptableObject
    {
        [SerializeField] public PatrolBehaviour[] behaviour;
    }
}