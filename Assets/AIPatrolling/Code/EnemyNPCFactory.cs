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
                SpawnConeOfView(enemyInstance, enemy.visionCone.distance, enemy.visionCone.fieldOfView, enemy.spawn.rotation.y);
                if (enemy.spawn.isStatic)
                {
                    enemyInstance.GetComponent<EnemyNPC>().SetStatic();
                }
                else if (enemy.spawn.onlyRotates)
                {
                    enemyInstance.GetComponent<EnemyNPC>().SetForOnlyRotation();
                }
                else if (enemy.spawn.onlyMovesInX)
                {
                    enemyInstance.GetComponent<EnemyNPC>().SetForOnlyXMovement();
                }
                else if (enemy.spawn.moves)
                {
                    enemyInstance.GetComponent<EnemyNPC>().SetForMovement();
                }
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

        #region LocalMethods

        protected void SpawnConeOfView(GameObject parent, float distance, float fieldOfView, float rotation)
        {
            coneInstance = Instantiate(coneOfVisionPrefab);
            coneInstance.transform.position = parent.transform.GetChild(0).position;
            coneInstance.transform.parent = parent.transform.GetChild(0);
            coneInstance.transform.rotation = parent.transform.rotation;
            coneInstance.transform.localScale = new Vector3(distance, 0.8f, distance);
            coneInstance.GetComponent<ConeOfVision>().SetOriginPoint = parent;
            for (float i = 0; i <= fieldOfView / 2; i += 10)
            {
                coneInstance = Instantiate(coneOfVisionPrefab);
                coneInstance.transform.position = parent.transform.GetChild(0).position;
                coneInstance.transform.parent = parent.transform.GetChild(0);
                coneInstance.transform.rotation = Quaternion.Euler(new Vector3 (0, rotation + i + 10, 0));
                coneInstance.transform.localScale = new Vector3(distance, 0.8f, distance);
                coneInstance.GetComponent<ConeOfVision>().SetOriginPoint = parent;

                coneInstance = Instantiate(coneOfVisionPrefab);
                coneInstance.transform.position = parent.transform.GetChild(0).position;
                coneInstance.transform.parent = parent.transform.GetChild(0);
                coneInstance.transform.rotation = Quaternion.Euler(new Vector3(0, rotation - i - 10, 0));
                coneInstance.transform.localScale = new Vector3(distance, 0.8f, distance);
                coneInstance.GetComponent<ConeOfVision>().SetOriginPoint = parent;
            }
        }

        #endregion
    }
}

