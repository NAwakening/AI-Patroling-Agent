using UnityEngine;

namespace N_Awakening.PatrolAgents
{
    #region Struct

    [System.Serializable]
    public struct PatrolBehaviour
    {
        public StateMechanic stateMechanic;
        [SerializeField] public Vector3 destinyDirection;
        public float time;
        public float speed;
    }

    [System.Serializable]
    public struct VisionConeParameters
    {
        public float distance;
        public float fieldOfView;
    }

    [System.Serializable]
    public struct SpawnParameters
    {
        [SerializeField] public Vector3 position;
        [SerializeField] public Vector3 rotation;
        [SerializeField] public bool isStatic;
        [SerializeField] public bool onlyRotates;
        [SerializeField] public bool onlyMovesInX;
        [SerializeField] public bool moves;
    }

    #endregion

    [CreateAssetMenu(menuName = "AIPatroling/EnemyNPC_SO")]
    public class EnemyNPC_SO : ScriptableObject
    {
        [SerializeField] public PatrolBehaviour[] behaviour;
        [SerializeField] public VisionConeParameters visionCone;
        [SerializeField] public SpawnParameters spawn;
    }
}
