using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform enemySpawnPoint;
    private List<Enemy> enemyPrefabs;

    private float xAxisSpawnRange;
    private float zAxisSpawnRange;

    private float enemysProbalitySum = 0;

    private Coroutine spawnCoroutine;
    private Transform playerTransform;

    private float enemySpawnTime = 2;
    private float minSpawnTime = 0.5f;


    public void Init(List<Enemy> enemyPrefabs, Transform playerTransform, float xAxisSpawnRange, float zAxisSpawnRange)
    {
        this.enemyPrefabs = enemyPrefabs.OrderBy(x => x.GetSpawmProbability()).ToList();
        this.playerTransform = playerTransform;

        this.xAxisSpawnRange = xAxisSpawnRange;
        this.zAxisSpawnRange = zAxisSpawnRange;

        for (int i = 0; i < this.enemyPrefabs.Count; i++)
        {
            enemysProbalitySum += this.enemyPrefabs[i].GetSpawmProbability();
        }

        enemySpawnTime = 2;
    }


    public void StartSpawnEnemy()
    {
        spawnCoroutine = StartCoroutine(EnemySpawnCoroutine());
        StartCoroutine(DicrementSpawnTimeCoroutine());
    }
    public void StopSpawnEnemy()
    {
        if(spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }



    private IEnumerator EnemySpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnTime);
            SpawnEnemy();
        }
    }


    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPoint();
        Enemy newEnemy = GetRandomEnemy();

        newEnemy = Instantiate(newEnemy, spawnPosition, Quaternion.identity);
        newEnemy.Init(playerTransform);

    }

    private Vector3 GetRandomSpawnPoint()
    {
        Vector3 result = Vector3.zero;
        enemySpawnPoint.position = new Vector3(Random.Range(-xAxisSpawnRange, xAxisSpawnRange), enemySpawnPoint.transform.position.y, Random.Range(-zAxisSpawnRange, zAxisSpawnRange));

        while (!IsVisablePosition(enemySpawnPoint))
            enemySpawnPoint.position = new Vector3(Random.Range(-xAxisSpawnRange, xAxisSpawnRange), enemySpawnPoint.transform.position.y, Random.Range(-zAxisSpawnRange, zAxisSpawnRange));
        
        result = enemySpawnPoint.position;

        return result;
    }

    private bool IsVisablePosition(Transform point)
    {
        bool result = false;
        Vector3 pointPosition = Camera.main.WorldToViewportPoint(point.position);

        result = pointPosition.x < 0.0f || pointPosition.x > 1.0f || pointPosition.y > 1.0f || pointPosition.y > 1.0f;


        return result;
    }


    public Enemy GetRandomEnemy()
    {
        Enemy result = null;
        float randChance = Random.Range(0, enemysProbalitySum);


        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            if (enemyPrefabs[i].GetSpawmProbability() > randChance)
            {
                result = enemyPrefabs[i];
                break;
            }

            randChance -= enemyPrefabs[i].GetSpawmProbability();
        }

        return result;

    }

    private IEnumerator DicrementSpawnTimeCoroutine()
    {
        while(enemySpawnTime > minSpawnTime)
        {
            yield return new WaitForSeconds(10f);
            enemySpawnTime -= 0.1f;
        }
    }

}
