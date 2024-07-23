using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> enemyPrefabs;



    private void OnEnable()
    {
        enemyPrefabs = enemyPrefabs.OrderBy(x => x.GetSpawmProbability()).ToList();
        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            Debug.Log("enemy" + enemyPrefabs[i].GetSpawmProbability());
        }

    }


    public Enemy GetRandomEnemy()
    {
        Enemy result = null;

        float randChance = Random.Range(0, 101);


        for(int i = 0; i < enemyPrefabs.Count; i++)
        {
            if (enemyPrefabs[i].GetSpawmProbability() <= randChance)
            {
                result = enemyPrefabs[i];
                break;
            }
        }



        return result;
    
    }
}
