using UnityEngine;
using UnityEngine.SceneManagement;

namespace N_Awakening.PatrolAgents
{
    public class GameManager : MonoBehaviour
    {
        #region References

        public static GameManager instance;

        [SerializeField] protected Transform player;
        [SerializeField] protected Transform spawnPosition;
        [SerializeField] protected GameObject endPanel;

        #endregion

        #region UnityMethods

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                endPanel.SetActive(true);
            }
        }

        #endregion

        #region PublicMethods

        public void ReloadScene(int id)
        {
            SceneManager.LoadScene(id);
        }

        public void ReturnPlayerToSpawn()
        {
            player.position = spawnPosition.position;
        }

        #endregion
    }
}