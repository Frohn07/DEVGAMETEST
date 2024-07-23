using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform enemySpawnPoint;
    private List<Enemy> enemyPrefabs;

    [SerializeField]
    private float xAxisSpawnRange;
    [SerializeField]
    private float zAxisSpawnRange;

    private float enemysProbalitySum = 0;

    private Coroutine spawnCoroutine;

    private Transform playerTransform;


    public void Init(List<Enemy> enemyPrefabs, Transform playerTransform)
    {
        this.enemyPrefabs = enemyPrefabs.OrderBy(x => x.GetSpawmProbability()).ToList();
        this.playerTransform = playerTransform;

        for (int i = 0; i < this.enemyPrefabs.Count; i++)
        {
            enemysProbalitySum += this.enemyPrefabs[i].GetSpawmProbability();
        }
    }


    public void StartSpawnEnemy()
    {
        spawnCoroutine = StartCoroutine(EnemySpawnCoroutine());
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
            yield return new WaitForSeconds(2f);
            SpawnEnemy();
        }
    }


    private void SpawnEnemy()
    {
        Vector3 spawnPoint = GetRandomSpawnPoint();
        Enemy newEnemy = GetRandomEnemy();

        newEnemy = Instantiate(newEnemy, spawnPoint, Quaternion.identity);
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

        Debug.Log("Is Visiable: " + result);

        return result;
    }


    public Enemy GetRandomEnemy()
    {
        Enemy result = null;
        float randChance = Random.Range(0, enemysProbalitySum);

        Debug.Log("rand chance: " + randChance);

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

}
