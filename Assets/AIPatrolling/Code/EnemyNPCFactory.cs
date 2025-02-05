using System.Collections.Generic;
using UnityEngine;

namespace N_Awakening.PatrolAgents
{
    public class EnemyNPCFactory : MonoBehaviour
    {
        #region References

        [Header("Parameters")]
        [SerializeField] protected EnemyNPC_SO[] enemyParameters;
        [SerializeField] protected GameObject enemyPrefab;
        [SerializeField] protected GameObject coneOfVisionPrefab;

        #endregion

        #region RuntimeVariables

        [Header("RuntimeVariables")]
        [SerializeField] protected List<GameObject> enemiesInstancesGameObject;
        GameObject enemyInstance;
        GameObject coneInstance;

        #endregion

        #region PublicMethods

        public void CreateEnemies()
        {
            foreach (EnemyNPC_SO enemy in enemyParameters)
            {
                enemyInstance = Instantiate(enemyPrefab);
                enemyInstance.transform.position = enemy.spawn.position;
                enemyInstance.transform.rotation = Quaternion.Euler(enemy.spawn.rotation);
                enemyInstance.transform.parent = transform;
                enemiesInstancesGameObject.Add(enemyInstance);
                enemyInstance.GetComponent<EnemyNPC>().SetBehaviour = enemy;
                //Do the field of view
            }
        }

        public void DestroyEnemies()
        {
            for (int i = enemiesInstancesGameObject.Count -1; i >= 0; i--)
            {
                enemyInstance = enemiesInstancesGameObject[i];
                enemiesInstancesGameObject.Remove(enemyInstance);
                DestroyImmediate(enemyInstance);
                
            }
            enemiesInstancesGameObject.Clear();
        }

        #endregion
    }
}

