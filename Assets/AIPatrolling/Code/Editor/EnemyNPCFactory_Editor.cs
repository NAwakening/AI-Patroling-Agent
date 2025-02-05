using UnityEngine;
using UnityEditor;

namespace N_Awakening.PatrolAgents
{
    [CustomEditor(typeof(EnemyNPCFactory))]
    public class EnemyNPCFactory_Editor : Editor
    {
        EnemyNPCFactory enemyNPCFactory;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            enemyNPCFactory = (EnemyNPCFactory)target;

            if (GUILayout.Button("Create Enemies"))
            {
                enemyNPCFactory.DestroyEnemies();
                enemyNPCFactory.CreateEnemies();
            }
            if (GUILayout.Button("Destroy Enemies"))
            {
                enemyNPCFactory.DestroyEnemies();
            }
        }
    }
}