using UnityEngine;

namespace N_Awakening.PatrolAgents
{
    public class ConeOfVision : MonoBehaviour
    {
        #region References

        [SerializeField] protected GameObject originPoint;

        #endregion

        #region RuntimeVariables

        RaycastHit hit;

        #endregion

        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            CheckVisibility(other.transform);
        }

        #endregion

        #region LocalMethods

        protected void CheckVisibility(Transform player)
        {
            if (Physics.Raycast(originPoint.transform.position, (player.position - originPoint.transform.position).normalized, out hit, Vector3.Distance(originPoint.transform.position, player.position)-1, LayerMask.GetMask("Walls")))
            {
                return;
            }
            else
            {
                GameManager.instance.ReturnPlayerToSpawn();
            }
        }

        #endregion

        #region GettersAndSetters

        public GameObject SetOriginPoint
        {
            set { originPoint = value; }
        }

        #endregion
    }
}