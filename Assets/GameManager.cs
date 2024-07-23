using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private EnemySpawner enemySpawner;

    [SerializeField]
    private List<Enemy> enemiePrefabs;



    public void INIT()
    {
        enemySpawner.Init(enemiePrefabs, player.transform);
    }

    private void Awake()
    {
        INIT();
    }
    private void Start()
    {
        enemySpawner.StartSpawnEnemy();
    }
}
