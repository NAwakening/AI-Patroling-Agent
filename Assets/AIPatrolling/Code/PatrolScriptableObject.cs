using UnityEngine;

namespace N_Awakening.AI_Patrol
{
    #region Enum

    public enum BehaviourType
    {
        Stop,
        Rotate,
        Move,
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


